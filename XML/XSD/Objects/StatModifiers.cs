// ------------------------------------------------------------------------------
//  <auto-generated>
//    Generated by Xsd2Code++. Version 6.0.22.0. www.xsd2code.com
//  </auto-generated>
// ------------------------------------------------------------------------------
#pragma warning disable
namespace Hybrasyl.Xml
{
using System;
using System.Diagnostics;
using System.Xml.Serialization;
using System.Runtime.Serialization;
using System.Collections;
using System.Xml.Schema;
using System.ComponentModel;
using System.Xml;
using System.IO;
using System.Text;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;

[System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.8.4161.0")]
[Serializable]
[DebuggerStepThrough]
[DesignerCategoryAttribute("code")]
[XmlTypeAttribute(Namespace="http://www.hybrasyl.com/XML/Hybrasyl/2020-02")]
public partial class StatModifiers
{
    #region Private fields
    private sbyte _str;
    private sbyte _int;
    private sbyte _wis;
    private sbyte _con;
    private sbyte _dex;
    private int _hp;
    private int _mp;
    private sbyte _hit;
    private sbyte _dmg;
    private sbyte _ac;
    private sbyte _regen;
    private sbyte _mr;
    private ElementType _offensiveElement;
    private ElementType _defensiveElement;
    private float _inboundDamageModifier;
    private float _outboundDamageModifier;
    private float _inboundModifier;
    private float _outboundModifier;
    private DamageType _damageType;
    private float _reflectChance;
    private float _reflectIntensity;
    private static XmlSerializer _serializerXml;
    #endregion
    
    public StatModifiers()
    {
        _str = ((sbyte)(0));
        _int = ((sbyte)(0));
        _wis = ((sbyte)(0));
        _con = ((sbyte)(0));
        _dex = ((sbyte)(0));
        _hp = 0;
        _mp = 0;
        _hit = ((sbyte)(0));
        _dmg = ((sbyte)(0));
        _ac = ((sbyte)(0));
        _regen = ((sbyte)(0));
        _mr = ((sbyte)(0));
    }
    
    [XmlAttribute]
    [DefaultValue(typeof(sbyte), "0")]
    public sbyte Str
    {
        get
        {
            return _str;
        }
        set
        {
            _str = value;
        }
    }
    
    [XmlAttribute]
    [DefaultValue(typeof(sbyte), "0")]
    public sbyte Int
    {
        get
        {
            return _int;
        }
        set
        {
            _int = value;
        }
    }
    
    [XmlAttribute]
    [DefaultValue(typeof(sbyte), "0")]
    public sbyte Wis
    {
        get
        {
            return _wis;
        }
        set
        {
            _wis = value;
        }
    }
    
    [XmlAttribute]
    [DefaultValue(typeof(sbyte), "0")]
    public sbyte Con
    {
        get
        {
            return _con;
        }
        set
        {
            _con = value;
        }
    }
    
    [XmlAttribute]
    [DefaultValue(typeof(sbyte), "0")]
    public sbyte Dex
    {
        get
        {
            return _dex;
        }
        set
        {
            _dex = value;
        }
    }
    
    [XmlAttribute]
    [DefaultValue(0)]
    public int Hp
    {
        get
        {
            return _hp;
        }
        set
        {
            _hp = value;
        }
    }
    
    [XmlAttribute]
    [DefaultValue(0)]
    public int Mp
    {
        get
        {
            return _mp;
        }
        set
        {
            _mp = value;
        }
    }
    
    [XmlAttribute]
    [DefaultValue(typeof(sbyte), "0")]
    public sbyte Hit
    {
        get
        {
            return _hit;
        }
        set
        {
            _hit = value;
        }
    }
    
    [XmlAttribute]
    [DefaultValue(typeof(sbyte), "0")]
    public sbyte Dmg
    {
        get
        {
            return _dmg;
        }
        set
        {
            _dmg = value;
        }
    }
    
    [XmlAttribute]
    [DefaultValue(typeof(sbyte), "0")]
    public sbyte Ac
    {
        get
        {
            return _ac;
        }
        set
        {
            _ac = value;
        }
    }
    
    [XmlAttribute]
    [DefaultValue(typeof(sbyte), "0")]
    public sbyte Regen
    {
        get
        {
            return _regen;
        }
        set
        {
            _regen = value;
        }
    }
    
    [XmlAttribute]
    [DefaultValue(typeof(sbyte), "0")]
    public sbyte Mr
    {
        get
        {
            return _mr;
        }
        set
        {
            _mr = value;
        }
    }
    
    [XmlAttribute]
    public ElementType OffensiveElement
    {
        get
        {
            return _offensiveElement;
        }
        set
        {
            _offensiveElement = value;
        }
    }
    
    [XmlAttribute]
    public ElementType DefensiveElement
    {
        get
        {
            return _defensiveElement;
        }
        set
        {
            _defensiveElement = value;
        }
    }
    
    [XmlAttribute]
    public float InboundDamageModifier
    {
        get
        {
            return _inboundDamageModifier;
        }
        set
        {
            _inboundDamageModifier = value;
        }
    }
    
    [XmlAttribute]
    public float OutboundDamageModifier
    {
        get
        {
            return _outboundDamageModifier;
        }
        set
        {
            _outboundDamageModifier = value;
        }
    }
    
    [XmlAttribute]
    public float InboundModifier
    {
        get
        {
            return _inboundModifier;
        }
        set
        {
            _inboundModifier = value;
        }
    }
    
    [XmlAttribute]
    public float OutboundModifier
    {
        get
        {
            return _outboundModifier;
        }
        set
        {
            _outboundModifier = value;
        }
    }
    
    [XmlAttribute]
    public DamageType DamageType
    {
        get
        {
            return _damageType;
        }
        set
        {
            _damageType = value;
        }
    }
    
    [XmlAttribute]
    public float ReflectChance
    {
        get
        {
            return _reflectChance;
        }
        set
        {
            _reflectChance = value;
        }
    }
    
    [XmlAttribute]
    public float ReflectIntensity
    {
        get
        {
            return _reflectIntensity;
        }
        set
        {
            _reflectIntensity = value;
        }
    }
    
    private static XmlSerializer SerializerXml
    {
        get
        {
            if ((_serializerXml == null))
            {
                _serializerXml = new XmlSerializerFactory().CreateSerializer(typeof(StatModifiers));
            }
            return _serializerXml;
        }
    }
    
    #region Serialize/Deserialize
    /// <summary>
    /// Serialize StatModifiers object
    /// </summary>
    /// <returns>XML value</returns>
    public virtual string Serialize()
    {
        StreamReader streamReader = null;
        MemoryStream memoryStream = null;
        try
        {
            memoryStream = new MemoryStream();
            System.Xml.XmlWriterSettings xmlWriterSettings = new System.Xml.XmlWriterSettings();
            xmlWriterSettings.Indent = true;
            xmlWriterSettings.IndentChars = "  ";
            System.Xml.XmlWriter xmlWriter = XmlWriter.Create(memoryStream, xmlWriterSettings);
            SerializerXml.Serialize(xmlWriter, this);
            memoryStream.Seek(0, SeekOrigin.Begin);
            streamReader = new StreamReader(memoryStream);
            return streamReader.ReadToEnd();
        }
        finally
        {
            if ((streamReader != null))
            {
                streamReader.Dispose();
            }
            if ((memoryStream != null))
            {
                memoryStream.Dispose();
            }
        }
    }
    
    /// <summary>
    /// Deserializes StatModifiers object
    /// </summary>
    /// <param name="input">string to deserialize</param>
    /// <param name="obj">Output StatModifiers object</param>
    /// <param name="exception">output Exception value if deserialize failed</param>
    /// <returns>true if this Serializer can deserialize the object; otherwise, false</returns>
    public static bool Deserialize(string input, out StatModifiers obj, out Exception exception)
    {
        exception = null;
        obj = default(StatModifiers);
        try
        {
            obj = Deserialize(input);
            return true;
        }
        catch (Exception ex)
        {
            exception = ex;
            return false;
        }
    }
    
    public static bool Deserialize(string input, out StatModifiers obj)
    {
        Exception exception = null;
        return Deserialize(input, out obj, out exception);
    }
    
    public static StatModifiers Deserialize(string input)
    {
        StringReader stringReader = null;
        try
        {
            stringReader = new StringReader(input);
            return ((StatModifiers)(SerializerXml.Deserialize(XmlReader.Create(stringReader))));
        }
        finally
        {
            if ((stringReader != null))
            {
                stringReader.Dispose();
            }
        }
    }
    
    public static StatModifiers Deserialize(Stream s)
    {
        return ((StatModifiers)(SerializerXml.Deserialize(s)));
    }
    #endregion
    
    /// <summary>
    /// Serializes current StatModifiers object into file
    /// </summary>
    /// <param name="fileName">full path of outupt xml file</param>
    /// <param name="exception">output Exception value if failed</param>
    /// <returns>true if can serialize and save into file; otherwise, false</returns>
    public virtual bool SaveToFile(string fileName, out Exception exception)
    {
        exception = null;
        try
        {
            SaveToFile(fileName);
            return true;
        }
        catch (Exception e)
        {
            exception = e;
            return false;
        }
    }
    
    public virtual void SaveToFile(string fileName)
    {
        StreamWriter streamWriter = null;
        try
        {
            string dataString = Serialize();
            FileInfo outputFile = new FileInfo(fileName);
            streamWriter = outputFile.CreateText();
            streamWriter.WriteLine(dataString);
            streamWriter.Close();
        }
        finally
        {
            if ((streamWriter != null))
            {
                streamWriter.Dispose();
            }
        }
    }
    
    /// <summary>
    /// Deserializes xml markup from file into an StatModifiers object
    /// </summary>
    /// <param name="fileName">File to load and deserialize</param>
    /// <param name="obj">Output StatModifiers object</param>
    /// <param name="exception">output Exception value if deserialize failed</param>
    /// <returns>true if this Serializer can deserialize the object; otherwise, false</returns>
    public static bool LoadFromFile(string fileName, out StatModifiers obj, out Exception exception)
    {
        exception = null;
        obj = default(StatModifiers);
        try
        {
            obj = LoadFromFile(fileName);
            return true;
        }
        catch (Exception ex)
        {
            exception = ex;
            return false;
        }
    }
    
    public static bool LoadFromFile(string fileName, out StatModifiers obj)
    {
        Exception exception = null;
        return LoadFromFile(fileName, out obj, out exception);
    }
    
    public static StatModifiers LoadFromFile(string fileName)
    {
        FileStream file = null;
        StreamReader sr = null;
        try
        {
            file = new FileStream(fileName, FileMode.Open, FileAccess.Read);
            sr = new StreamReader(file);
            string dataString = sr.ReadToEnd();
            sr.Close();
            file.Close();
            return Deserialize(dataString);
        }
        finally
        {
            if ((file != null))
            {
                file.Dispose();
            }
            if ((sr != null))
            {
                sr.Dispose();
            }
        }
    }
}
}
#pragma warning restore
