using System.Collections.Generic;
using System.Xml;
using UnityEngine;
using System.Collections;

public enum LanguageType
{
    Chinese,
    English,
    Japanese
}

public class TableLanguage : Table<TableLanguage>, ITable
{
    private Dictionary<int, string> dicCn = new Dictionary<int, string>();
    private Dictionary<int, string> dicEn = new Dictionary<int, string>();
    private Dictionary<int, string> dicJp = new Dictionary<int, string>();

    public void Read()
    {
        XmlDocument xmldoc = new XmlDocument();
        string xmlText = xLoad("Language");
        xmldoc.LoadXml(xmlText);
        XmlNodeList nodelist = xmldoc.SelectSingleNode("root").ChildNodes;
        foreach (XmlNode node in nodelist)
        {
            XmlAttributeCollection xAC = node.Attributes;
            GetAttribute g = new GetAttribute(xAC);
            int id = int.Parse(node.Name.Replace("ID", ""));
            if (!dicCn.ContainsKey(id))
            {
                dicCn.Add(id, g.getString("cn"));
            }
            if (!dicEn.ContainsKey(id))
            {
                dicEn.Add(id, g.getString("en"));
            }
            if (!dicJp.ContainsKey(id))
            {
                dicJp.Add(id, g.getString("jp"));
            }
        }
        HasReadToMemory = true;
        Debug.Log("TableLanguageLoadDone!");
    }

    public string GetTextById(int id, LanguageType type)
    {
        if (type == LanguageType.Chinese)
        {
            foreach (KeyValuePair<int, string> pair in dicCn)
            {
                if (pair.Key == id)
                {
                    return pair.Value;
                }
            }
        }
        else if (type == LanguageType.English)
        {
            foreach (KeyValuePair<int, string> pair in dicEn)
            {
                if (pair.Key == id)
                {
                    return pair.Value;
                }
            }
        }
        else if (type == LanguageType.Japanese)
        {
            foreach (KeyValuePair<int, string> pair in dicJp)
            {
                if (pair.Key == id)
                {
                    return pair.Value;
                }
            }
        }
        Debug.LogError("Can't find this id:" + id);
        return null;
    }

    public int GetIdByText(string text)
    {
        foreach (KeyValuePair<int, string> pair in dicCn)
        {
            if (pair.Value == text)
            {
                return pair.Key;
            }
        }
        foreach (KeyValuePair<int, string> pair in dicEn)
        {
            if (pair.Value == text)
            {
                return pair.Key;
            }
        }
        foreach (KeyValuePair<int, string> pair in dicJp)
        {
            if (pair.Value == text)
            {
                return pair.Key;
            }
        }
        Debug.Log("Can't find this text!");
        return 0;
    }
}
    

