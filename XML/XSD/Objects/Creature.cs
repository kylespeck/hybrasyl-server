// ------------------------------------------------------------------------------
//  <auto-generated>
//    Generated by Xsd2Code++. Version 5.2.97.0. www.xsd2code.com
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
[System.ComponentModel.DesignerCategoryAttribute("code")]
[XmlTypeAttribute(Namespace="http://www.hybrasyl.com/XML/Hybrasyl/2020-02")]
[XmlRootAttribute(Namespace="http://www.hybrasyl.com/XML/Hybrasyl/2020-02", IsNullable=false)]
public partial class Creature
{
    #region Private fields
    private string _description;
    private LootList _loot;
    private CreatureHostilitySettings _hostility;
    private List<CreatureCookie> _setCookies;
    private List<Creature> _types;
    private string _name;
    private ushort _sprite;
    private string _behaviorSet;
    private int _minDmg;
    private int _maxDmg;
    private static XmlSerializer _serializer;
    #endregion
    
    public Creature()
    {
        _minDmg = 0;
        _maxDmg = 0;
    }
    
    [StringLengthAttribute(255, MinimumLength=1)]
    public string Description
    {
        get
        {
            return _description;
        }
        set
        {
            _description = value;
        }
    }
    
    public LootList Loot
    {
        get
        {
            return _loot;
        }
        set
        {
            _loot = value;
        }
    }
    
    public CreatureHostilitySettings Hostility
    {
        get
        {
            return _hostility;
        }
        set
        {
            _hostility = value;
        }
    }
    
    [XmlArrayItemAttribute("Cookie", IsNullable=false)]
    public List<CreatureCookie> SetCookies
    {
        get
        {
            return _setCookies;
        }
        set
        {
            _setCookies = value;
        }
    }
    
    [XmlArrayItemAttribute("Type", IsNullable=false)]
    public List<Creature> Types
    {
        get
        {
            return _types;
        }
        set
        {
            _types = value;
        }
    }
    
    [XmlAttribute]
    public string Name
    {
        get
        {
            return _name;
        }
        set
        {
            _name = value;
        }
    }
    
    [XmlAttribute]
    public ushort Sprite
    {
        get
        {
            return _sprite;
        }
        set
        {
            _sprite = value;
        }
    }
    
    [XmlAttribute]
    public string BehaviorSet
    {
        get
        {
            return _behaviorSet;
        }
        set
        {
            _behaviorSet = value;
        }
    }
    
    [XmlAttribute]
    [DefaultValue(0)]
    public int MinDmg
    {
        get
        {
            return _minDmg;
        }
        set
        {
            _minDmg = value;
        }
    }
    
    [XmlAttribute]
    [DefaultValue(0)]
    public int MaxDmg
    {
        get
        {
            return _maxDmg;
        }
        set
        {
            _maxDmg = value;
        }
    }
    
    private static XmlSerializer SerializerXML
    {
        get
        {
            if ((_serializer == null))
            {
                _serializer = new XmlSerializerFactory().CreateSerializer(typeof(Creature));
            }
            return _serializer;
        }
    }
    
    #region Serialize/Deserialize
    /// <summary>
    /// Serialize Creature object
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
            SerializerXML.Serialize(xmlWriter, this);
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
    /// Deserializes Creature object
    /// </summary>
    /// <param name="input">string workflow markup to deserialize</param>
    /// <param name="obj">Output Creature object</param>
    /// <param name="exception">output Exception value if deserialize failed</param>
    /// <returns>true if this Serializer can deserialize the object; otherwise, false</returns>
    public static bool Deserialize(string input, out Creature obj, out Exception exception)
    {
        exception = null;
        obj = default(Creature);
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
    
    public static bool Deserialize(string input, out Creature obj)
    {
        Exception exception = null;
        return Deserialize(input, out obj, out exception);
    }
    
    public static Creature Deserialize(string input)
    {
        StringReader stringReader = null;
        try
        {
            stringReader = new StringReader(input);
            return ((Creature)(SerializerXML.Deserialize(XmlReader.Create(stringReader))));
        }
        finally
        {
            if ((stringReader != null))
            {
                stringReader.Dispose();
            }
        }
    }
    
    public static Creature Deserialize(Stream s)
    {
        return ((Creature)(SerializerXML.Deserialize(s)));
    }
    #endregion
    
    /// <summary>
    /// Serializes current Creature object into file
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
    /// Deserializes xml markup from file into an Creature object
    /// </summary>
    /// <param name="fileName">string xml file to load and deserialize</param>
    /// <param name="obj">Output Creature object</param>
    /// <param name="exception">output Exception value if deserialize failed</param>
    /// <returns>true if this Serializer can deserialize the object; otherwise, false</returns>
    public static bool LoadFromFile(string fileName, out Creature obj, out Exception exception)
    {
        exception = null;
        obj = default(Creature);
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
    
    public static bool LoadFromFile(string fileName, out Creature obj)
    {
        Exception exception = null;
        return LoadFromFile(fileName, out obj, out exception);
    }
    
    public static Creature LoadFromFile(string fileName)
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
