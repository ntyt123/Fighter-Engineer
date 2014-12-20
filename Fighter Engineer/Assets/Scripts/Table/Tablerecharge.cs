using System;
using System.Xml;
using UnityEngine;
using System.Collections;
using System.Collections.Generic;
public class RechargeItem
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
public class TableRecharge : Table<TableRecharge>, ITable
{
    Dictionary<int, RechargeItem> dicRechargeList = new Dictionary<int, RechargeItem>();
    public void Read()
    {
        XmlDocument xmldoc = new XmlDocument();
        string xmlText = xLoad("Recharge");
        xmldoc.LoadXml(xmlText);
        XmlNodeList nodelist = xmldoc.SelectSingleNode("root").ChildNodes;
        foreach (XmlNode node in nodelist)
        {
            XmlAttributeCollection xAC = node.Attributes;
            GetAttribute g = new GetAttribute(xAC);
            int id = int.Parse(node.Name.Replace("ID", ""));
            RechargeItem info = new RechargeItem();
            info.ID = id;
            info.CnName = g.getString("CnName");
            info.CnContent = g.getString("CnContent");
            info.EnName = g.getString("EnName");
            info.EnContent = g.getString("EnContent");
            info.JpName = g.getString("JpName");
            info.JpContent = g.getString("JpContent");
            info.Price = g.getInt("Price");
            info.GemNum = g.getInt("GemNum");
            if (!dicRechargeList.ContainsKey(id))
            {
                dicRechargeList.Add(id, info);
            }
        }
        HasReadToMemory = true;
        Debug.Log("TableRechargeLoadDone!");
    }
}
