﻿/*
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

using System.Timers;

namespace Hybrasyl.Jobs;

public static class RegenerationJob
{
    public static readonly int Interval = 25;

    public static void Execute(object obj, ElapsedEventArgs args)
    {
        foreach (var connId in GlobalConnectionManifest.WorldClients.Keys)
            World.ControlMessageQueue.Add(new HybrasylControlMessage(ControlOpcodes.RegenUser, connId));
    }
}