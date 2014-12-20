using UnityEngine;
using System.Collections;
using System;
using System.Xml;
using System.Collections.Generic;

public class Achievement
{
    public int ID;
    public string CnName;
    public string CnContent;
    public string EnName;
    public string EnContent;
    public string JpName;
    public string JpContent;
    public int Gem;
}
public class TableAchievement : Table<TableAchievement>, ITable
{
    public Dictionary<int, Achievement> dicAchievement= new Dictionary<int, Achievement>();
    public void Read()
    {
        
        XmlDocument xmldoc = new XmlDocument();
        string xmlText = xLoad("Achievement");
        xmldoc.LoadXml(xmlText);
        XmlNodeList nodelist = xmldoc.SelectSingleNode("root").ChildNodes;
        foreach (XmlNode node in nodelist)
        {
            XmlAttributeCollection xAC = node.Attributes;
            GetAttribute g = new GetAttribute(xAC);
            int id = int.Parse(node.Name.Replace("ID", ""));
            Achievement info = new Achievement();
            info.ID = id;
            info.CnName = g.getString("CnName");
            info.CnContent = g.getString("CnContent");
            info.EnName = g.getString("EnName");
            info.EnContent = g.getString("EnContent");
            info.JpName = g.getString("JpName");
            info.JpContent = g.getString("JpContent");
            info.Gem = g.getInt("Gem");
            if (!dicAchievement.ContainsKey(id))
            {
                dicAchievement.Add(id, info);
            }
        }
        HasReadToMemory = true;
        Debug.Log("TableAchievementLoadDone!");
    }

    public Achievement GetAchievement(int id)
    {
        foreach (KeyValuePair<int, Achievement> pair in dicAchievement)
        {
            if (pair.Value.ID == id)
            {
                return pair.Value;
            }
        }
        return null;
    }
}
