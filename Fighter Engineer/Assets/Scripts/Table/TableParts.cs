using UnityEngine;
using System.Collections;
using System;
using System.Xml;
using System.Collections.Generic;

public class PartsInfo
{
    public int ID;
    public string CnName;
    public string CnContent;
    public string EnName;
    public string EnContent;
    public string JpName;
    public string JpContent;
    public int Type;
    public int HP;
    public int ATK;
    public int SPD;
    public int Score;
    public int Price;
    public int GemPrice;
    public int Mass;
}
public class TableParts : Table<TableParts>, ITable
{
    public Dictionary<int, PartsInfo> dicParts = new Dictionary<int, PartsInfo>();
    public void Read()
    {
        XmlDocument xmldoc = new XmlDocument();
        string xmlText = xLoad("Parts");
        xmldoc.LoadXml(xmlText);
        XmlNodeList nodelist = xmldoc.SelectSingleNode("root").ChildNodes;
        foreach (XmlNode node in nodelist)
        {
            XmlAttributeCollection xAC = node.Attributes;
            GetAttribute g = new GetAttribute(xAC);
            int id = int.Parse(node.Name.Replace("ID", ""));
            PartsInfo info = new PartsInfo();
            info.ID = id;
            info.CnName = g.getString("CnName");
            info.ATK = g.getInt("ATK");
            info.CnContent = g.getString("CnContent");
            info.EnName = g.getString("EnName");
            info.EnContent = g.getString("EnContent");
            info.JpName = g.getString("JpName");
            info.JpContent = g.getString("JpContent");
            info.Score = g.getInt("Score");
            info.GemPrice = g.getInt("GemPrice");
            info.HP = g.getInt("HP");
            info.Mass = g.getInt("Mass");
            info.Price = g.getInt("Price");
            info.SPD = g.getInt("SPD");
            info.Type = g.getInt("Type");
            if (!dicParts.ContainsKey(id))
            {
                dicParts.Add(id, info);
            }
        }
        HasReadToMemory = true;
        Debug.Log("TablePartsLoadDone!");
    }

    public PartsInfo GetPartsInfo(int id)
    {
        foreach (KeyValuePair<int, PartsInfo> pair in dicParts)
        {
            if (pair.Value.ID == id)
            {
                return pair.Value;
            }
        }
        return null;
    }
}
