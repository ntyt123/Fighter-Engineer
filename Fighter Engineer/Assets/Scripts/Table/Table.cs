using UnityEngine;
using System.Collections;
public interface ITable
{
    void Read();
}
public class Table<T> where T :ITable,new (){
    public static T _instance = default(T);
    public static object lockObj=new object();
    public static bool HasReadToMemory = false;

    public static T GetInstance()
    {
        if (_instance == null)
        {
            lock (lockObj)
            {
                if (_instance == null)
                    _instance = new T();
                if (!HasReadToMemory)
                    _instance.Read();
            }
        }
        return _instance;
    }
    public string xLoad(string fileName)
    {
        string Path = "XML/" + fileName;
        TextAsset textAsset = Resources.Load(Path) as TextAsset;
        if (textAsset == null)
        {
            Debug.Log("Can not find " + fileName);
            return null;
        }
        return textAsset.text;
    }
}
