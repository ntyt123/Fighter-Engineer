using UnityEngine;
using System.Collections;
using System;
using System.Collections.Generic;
using System.Xml;

public class EnemyInfo
{
    public int ID;
    public string CnName;
    public string JpName;
    public string EnName;
    public int Lv;
    public int Score;
    public int Money;
    public double Gem;
}
public class TableEnemy : Table<TableEnemy>, ITable
{
   public Dictionary<int, EnemyInfo> dicEnemy = new Dictionary<int, EnemyInfo>();
    public void Read()
    {
        XmlDocument xmldoc = new XmlDocument();
        string xmlText = xLoad("Enemy");
        xmldoc.LoadXml(xmlText);
        XmlNodeList nodelist = xmldoc.SelectSingleNode("root").ChildNodes;
        foreach (XmlNode node in nodelist)
        {
            XmlAttributeCollection xAC = node.Attributes;
            GetAttribute g = new GetAttribute(xAC);
            int id = int.Parse(node.Name.Replace("ID", ""));
            EnemyInfo info = new EnemyInfo();
            info.ID = id;
            info.CnName = g.getString("CnName");
            info.EnName = g.getString("EnName");
            info.JpName = g.getString("JpName");
            info.Money = g.getInt("Money");
            info.Lv = g.getInt("Lv");
            info.Score = g.getInt("Score");
            info.Gem = g.getFloat("Gem");
            if (!dicEnemy.ContainsKey(id))
            {
                dicEnemy.Add(id, info);
            }
        }
        HasReadToMemory = true;
        Debug.Log("TableEnemyLoadDone!");
    }

    public EnemyInfo GetEnemy(int id)
    {
        foreach (KeyValuePair<int, EnemyInfo> pair in dicEnemy)
        {
            if (pair.Value.ID == id)
            {
                return pair.Value;
            }
        }
        return null;
    }
}
