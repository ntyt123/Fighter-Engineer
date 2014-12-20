using System;
using System.Xml;
using UnityEngine;
using System.Collections;
public class ShopItem
{
    public int ID;
    public string CnName;
    public string EnName;
    public string JpName;
    public string CnContent;
    public string EnContent;
    public string JpContent;
    public int Price;
    public int GemNum;
}
public class TableShop : Table<TableShop>,ITable
{

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
}
