﻿using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Security.Cryptography;
using System.Text;
using System.Xml.Serialization;
using Newtonsoft.Json;
using Newtonsoft.Json.Bson;

namespace Hybrasyl.Xml;

public partial class Item
{
    public static SHA256 sha = SHA256.Create();

    [XmlIgnore] public bool IsVariant { get; set; }

    [XmlIgnore] public Item ParentItem { get; set; }

    [XmlIgnore]
    public List<string> Categories
    {
        get
        {
            if (Properties?.Categories is not null)
                return Properties.Categories.Select(selector: x => x.Value.ToLower()).ToList();
            return new List<string>();
        }
    }

    [XmlIgnore] public Dictionary<string, List<Item>> Variants { get; set; }

    public IEnumerable<SlotRestriction> SlotRequirements =>
        (Properties.Restrictions?.SlotRestrictions ?? new List<SlotRestriction>()).Where(predicate: x =>
            x.Type == SlotRestrictionType.ItemRequired);

    public IEnumerable<SlotRestriction> SlotProhibits =>
        (Properties.Restrictions?.SlotRestrictions ?? new List<SlotRestriction>()).Where(predicate: x =>
            x.Type == SlotRestrictionType.ItemProhibited);

    public string Id => GenerateId(Name, Gender);
    public int IdInt => int.Parse(Id, NumberStyles.HexNumber);

    public static List<string> GenerateIds(string name) =>
        (from Gender gender in Enum.GetValues(typeof(Gender)) select GenerateId(name, gender)).ToList();

    public static string GenerateId(string name, Gender gender)
    {
        var rawhash = $"{name.Normalize().ToLower()}:{gender.ToString().Normalize()}";
        var hash = sha.ComputeHash(Encoding.ASCII.GetBytes(rawhash));
        return string.Concat(hash.Select(selector: b => b.ToString("x2")))[..8];
    }

    public Item Clone()
    {
        var ms = new MemoryStream();
        var writer = new BsonWriter(ms);
        var reader = new BsonReader(ms);
        var serializer = new JsonSerializer();
        serializer.Serialize(writer, this);
        ms.Position = 0;
        var obj = serializer.Deserialize<Item>(reader);
        ms.Close();
        return obj;    }

    public Item RandomVariant(string variant)
    {
        if (Variants.ContainsKey(variant)) return Variants[variant].PickRandom();
        return null;
    }

    #region Accessors to provide defaults

    [XmlIgnore]
    public bool Stackable
    {
        get
        {
            if (Properties.Stackable != null) return Properties.Stackable.Max != 1;
            return false;
        }
    }

    [XmlIgnore] public int MaximumStack => Properties.Stackable?.Max ?? 0;

    [XmlIgnore] public byte MinLevel => Properties.Restrictions?.Level?.Min ?? 1;

    [XmlIgnore] public byte MinAbility => Properties.Restrictions?.Ab?.Min ?? 0;

    [XmlIgnore] public byte MaxLevel => Properties.Restrictions?.Level?.Max ?? 255;

    [XmlIgnore] public byte MaxAbility => Properties.Restrictions?.Level?.Max ?? 255;

    [XmlIgnore]
    public ElementType Element
    {
        get
        {
            var off = Properties.StatModifiers?.BaseOffensiveElement ?? ElementType.None;
            var def = Properties.StatModifiers?.BaseDefensiveElement ?? ElementType.None;
            return Properties.Equipment?.Slot == EquipmentSlot.Necklace ? off : def;
        }
    }

    [XmlIgnore] public bool Usable => Properties.Use != null;

    [XmlIgnore] public Use Use => Properties.Use;

    [XmlIgnore] public Class Class => Properties.Restrictions?.Class ?? Class.Peasant;

    [XmlIgnore] public Gender Gender => Properties.Restrictions?.Gender ?? Gender.Neutral;

    [XmlIgnore] public ushort MinLDamage => Properties.Damage?.Large.Min ?? 0;

    [XmlIgnore] public ushort MaxLDamage => Properties.Damage?.Large.Max ?? 0;

    [XmlIgnore] public ushort MinSDamage => Properties.Damage?.Small.Min ?? 0;

    [XmlIgnore] public ushort MaxSDamage => Properties.Damage?.Small.Max ?? 0;

    [XmlIgnore] public Variant CurrentVariant { get; set; }

    #endregion
}