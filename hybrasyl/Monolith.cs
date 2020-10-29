/*
 * This file is part of Project Hybrasyl.
 *
 * This program is free software; you can redistribute it and/or modify
 * it under the terms of the Affero General Public License as published by
 * the Free Software Foundation, version 3.
 *
 * This program is distributed in the hope that it will be useful, but
 * without ANY WARRANTY; without even the implied warranty of MERCHANTABILITY
 * or FITNESS FOR A PARTICULAR PURPOSE. See the Affero General Public License
 * for more details.
 *
 * You should have received a copy of the Affero General Public License along
 * with this program. If not, see <http://www.gnu.org/licenses/>.
 *
 * (C) 2020 ERISCO, LLC 
 *
 * For contributors and individual authors please refer to CONTRIBUTORS.MD.
 * 
 */

using Hybrasyl.Objects;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Threading;

namespace Hybrasyl
{


    //This class is defined to control the mob spawning thread.
    internal class Monolith
    {
        private static readonly ManualResetEvent AcceptDone = new ManualResetEvent(false);
        private static Random _random;


        private IEnumerable<Xml.SpawnGroup> SpawnGroups => Game.World.WorldData.Values<Xml.SpawnGroup>();
        private IEnumerable<Map> Maps => Game.World.WorldData.Values<Map>();
        private IEnumerable<Xml.Creature> Creatures => Game.World.WorldData.Values<Xml.Creature>();

        private ConcurrentDictionary<int, List<Xml.Spawn>> Spawns;

        internal Monolith()
        {
            _random = new Random();
            Spawns = new ConcurrentDictionary<int, List<Xml.Spawn>>();
        }

        public void Start()
        {
            // Resolve active spawns
            foreach (var spawnmap in Maps)
            foreach (var spawngroup in SpawnGroups)
            {               
                foreach (var spawnmap in spawngroup.Maps)
                {
                    if (Game.World.WorldData.TryGetValueByIndex(spawnmap.Name, out Map map))
                    {
                        spawnmap.Id = map.Id;
                        spawnmap.LastSpawn = DateTime.MinValue;
                    }
                    else
                    {
                        spawnmap.Disabled = true;
                        GameLog.SpawnError("Specified map {map} not found", spawnmap.Name);
                    }
                }
            }

            while (true)
            {
                if (World.ControlMessageQueue.IsCompleted)
                    break;
                foreach (var spawnGroup in SpawnGroups)
                    if (!spawnGroup.Disabled)
                        Spawn(spawnGroup);
                Thread.Sleep(5000);
            }
        }
    

        public void Spawn(Xml.SpawnGroup spawnGroup)
        {
            foreach (var map in spawnGroup.Maps)
            {
                if (map.Disabled) continue;
                try
                {
                    var spawnMap = Game.World.WorldData.Get<Map>(map.Id);
                    GameLog.SpawnDebug("Spawn: calculating {0}", spawnMap.Name);
                    var monsterList = spawnMap.Objects.OfType<Monster>().ToList();
                    var monsterCount = monsterList.Count;

                    // If there is no limit specified, we want a reasonable limit, which we consider to be 1/10th of total 
                    // number of map tiles

                    var spawnLimit = map.Limit == 0 ? (spawnMap.X * spawnMap.Y) / 10 : map.Limit;

                    if (monsterCount > spawnLimit)
                    {
                        if (spawnMap.SpawnDebug) GameLog.SpawnInfo($"Spawn: {map.Name}: not spawning, mob count is {monsterCount}, limit is {spawnLimit}");
                        continue;
                    }

                    var since = DateTime.Now - map.LastSpawn;
                    if (since.TotalSeconds < map.Interval)
                    {
                        if (spawnMap.SpawnDebug) GameLog.SpawnInfo($"Spawn: {map.Name}: not spawning, last spawn was {since.TotalSeconds} ago, interval {map.Interval}");
                        continue;
                    }

                    map.LastSpawn = DateTime.Now;

                    var thisSpawn = _random.Next(map.MinSpawn, map.MaxSpawn + 1);

                    GameLog.SpawnInfo($"Spawn: {map.Name}: spawning {thisSpawn} mobs ");

                    for (var i = 0; i < thisSpawn; i++)
                    {
                        var spawn = spawnGroup.Spawns.PickRandom(true);

                        if (spawn == null)
                        {
                            GameLog.SpawnError("Spawngroup empty, skipping");
                            break;
                        }

                        var creature = Creatures.FirstOrDefault(x => x.Name == spawn.Base);

                        if (creature is default(Xml.Creature))
                        {
                            GameLog.SpawnError($"Base monster {spawn.Base} not found");
                            break;
                        }
                        
                        var newSpawnLoot = LootBox.CalculateLoot(spawn);

                        if (spawnMap.SpawnDebug)
                            GameLog.SpawnInfo("Spawn {name}, map {map}: {Xp} xp, {Gold} gold, items {Items}", spawn.Base, map.Name, newSpawnLoot.Xp, newSpawnLoot.Gold,
                                string.Join(',', newSpawnLoot.Items));

                        var baseMob = new Monster(creature, spawn, map.Id, newSpawnLoot);
                        var mob = (Monster)baseMob.Clone();
                        var xcoord = 0;
                        var ycoord = 0;

                        if (map.Coordinates.Count > 0)
                        {
                            // TODO: optimize / improve
                            foreach (var coord in map.Coordinates)
                            {
                                if (spawnMap.EntityTree.GetObjects(new System.Drawing.Rectangle(coord.X, coord.Y, 1, 1)).Where(e => e is Creature).Count() == 0)
                                {
                                    xcoord = coord.X;
                                    ycoord = coord.Y;
                                    break;
                                }
                            }                         
                        }
                        else
                        {
                            do
                            {
                                xcoord = _random.Next(0, spawnMap.X);
                                ycoord = _random.Next(0, spawnMap.Y);
                            } while (spawnMap.IsWall[xcoord, ycoord]);
                        }
                        mob.X = (byte)xcoord;
                        mob.Y = (byte)ycoord;
                        if (spawnMap.SpawnDebug) GameLog.SpawnInfo($"Spawn: spawning {mob.Name} on {spawnMap.Name}");
                        SpawnMonster(mob, spawnMap);
                    }
                   
                }
                catch (Exception e)
                {
                    Game.ReportException(e);
                    GameLog.SpawnError(e, "Spawngroup {Filename}: disabled map {Name} due to error", spawnGroup.Filename, map.Name);
                    map.Disabled = true;
                    continue;
                }
            }
        }
        private static void SpawnMonster(Monster monster, Map map)
        {
            if (!World.ControlMessageQueue.IsCompleted)
            {
                World.ControlMessageQueue.Add(new HybrasylControlMessage(ControlOpcodes.MonolithSpawn, monster, map));
                //Game.World.Maps[mapId].InsertCreature(monster);
                if (map.SpawnDebug)
                    GameLog.SpawnInfo("Spawning monster: {0} {1} at {2}, {3}", map.Name, monster.Name, (int)monster.X, (int)monster.Y);
            }
        }
    }

    internal class MonolithControl
    {
        private IEnumerable<Map> _maps { get; set; }
        private static Random _random;

        internal MonolithControl()
        {
            _random = new Random();
            _maps = Game.World.WorldData.Values<Map>().ToList();
        }
        
        public void Start()
        {
            var x = 0;
            while (true)
            {               
                // Ignore processing if no one is logged in, what's the point

                try
                {
                    foreach (var map in _maps)
                    {
                        if (map.Users.Count == 0) continue;

                        foreach (var obj in map.Objects.Where(x => x is Monster).ToList())
                        {
                            if(obj is Monster mob)
                            {
                                if(mob.Active)
                                {
                                    Evaluate(mob, map);
                                }
                            }
                            
                        }
                    }
                }
                catch (Exception e)
                {
                    GameLog.Fatal("Monolith thread error: {e}", e);
                }
                Thread.Sleep(1000);
                x++;
                // Refresh our list every 15 seconds in case of XML reloading
                if (x == 30)
                {
                    _maps = Game.World.WorldData.Values<Map>().ToList();
                    x = 0;
                }
            }
        }


        private static void Evaluate(Monster monster, Map map)
        {
            if (!(monster.LastAction < DateTime.Now.AddMilliseconds(-monster.ActionDelay))) return;

            if (monster.Stats.Hp == 0 || monster.AiDisabled)
                return;

            if (map.Users.Count == 0)
                // Mobs on empty maps don't move, it's a waste of time
                return;
            if (!World.ControlMessageQueue.IsCompleted)
                World.ControlMessageQueue.Add(new HybrasylControlMessage(ControlOpcodes.MonolithControl, monster, map));
        }
    }
}
