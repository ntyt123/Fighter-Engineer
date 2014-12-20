using UnityEngine;
using System.Collections;
using System.Xml;

public class GetAttribute
{
    private XmlAttributeCollection _xmlAttributeCollection;

    public GetAttribute(XmlAttributeCollection xmlAttributeCollection)
    {
        _xmlAttributeCollection = xmlAttributeCollection;
    }

    public int getInt(string attributeName)
    {
        if (_xmlAttributeCollection[attributeName] == null)
        {
            return 0;
        }
        string s = _xmlAttributeCollection[attributeName].Value;
        if (s.Equals(""))
        {
            return 0;
        }
        return int.Parse(s);
    }
    public float getFloat(string attributeName)
    {
        if (_xmlAttributeCollection[attributeName] == null)
        {
            return 0;
        }
        string s = _xmlAttributeCollection[attributeName].Value;
        if (s.Equals(""))
        {
            return 0;
        }
        return float.Parse(s);
    }
    public string getString(string attributeName)
    {
        if (_xmlAttributeCollection[attributeName] == null)
        {
            return "";
        }
        string s = _xmlAttributeCollection[attributeName].Value;
        if (s.Equals(""))
        {
            return "";
        }
        return s;
    }
    public bool getBool(string attributeName)
    {
        if (_xmlAttributeCollection[attributeName] == null)
        {
            return false;
        }
        string s = _xmlAttributeCollection[attributeName].Value;
        if (s.Equals(""))
        {
            return false;
        }
        return bool.Parse(s);
    }
}
