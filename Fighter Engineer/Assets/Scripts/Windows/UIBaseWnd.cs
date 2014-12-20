using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class UIBaseWnd {
    //存储窗口的列表
    public static Dictionary<string,UIBaseWnd> dicWnd=new Dictionary<string, UIBaseWnd>();

    public enum wndStatus
    {
        wndClose,
        wndOpen,
    }
    /// <summary>
    /// 根据名字找窗体
    /// </summary>
    /// <param name="name">窗体名</param>
    /// <returns></returns>
    public static UIBaseWnd GetWndByName(string name)
    {
        if (dicWnd.ContainsKey(name))
        {
            return dicWnd[name];
        }
        return null;
    }
    //代表窗体的prefab
    public GameObject WndRootGameObject;
    //窗体状态
    protected wndStatus m_wndStatus;
    //窗体prefab的asset
    protected GameObject PrefabAsset;
    //窗体名
    public string m_wndName;
    //窗体prefab的路径
    protected string PrefabPath;
    //是否互斥
    protected bool m_ifMutex;
    //存储当前互斥窗口
    private static string mutexWnd;
    public virtual void Init(string wndName, string prefabPath, bool ifMutex)
    {
        m_wndName = wndName;
        PrefabPath = prefabPath;
        m_ifMutex = ifMutex;
    }

    public virtual void OpenWnd()
    {
        if (PrefabPath == null)
        {
            Debug.LogError("Open window " + m_wndName + "fail!" + "Please check PrefabPath");
            return;
        }
        //不能重复打开窗口
        if (dicWnd.ContainsKey(m_wndName) && dicWnd[m_wndName].IsOpen())
        {
            Debug.LogWarning("Can't Open window more than once!");
            return;
        }
        //关闭当前互斥的窗口
        if (mutexWnd != null && mutexWnd != m_wndName)
        {
            //GameApp.GetUIManager().CloseWnd(mutexWnd);
            mutexWnd = null;
        }
    }

    /// <summary>
    /// 窗口是否打开着
    /// </summary>
    public virtual bool IsOpen()
    {
        return m_wndStatus == wndStatus.wndOpen;
    }

    /// <summary>
    /// 窗口是否关闭着
    /// </summary>
    public virtual bool IsClose()
    {
        return m_wndStatus == wndStatus.wndClose;
    }
    /// <summary>
    /// 获取窗口状态
    /// </summary>
    /// <returns></returns>
    public virtual wndStatus GetWndStatus()
    {
        return m_wndStatus;
    }
    /// <summary>
    /// 设置窗口当前状态
    /// </summary>
    /// <param name="e"></param>
    public virtual void SetWndStatus(wndStatus e)
    {
        m_wndStatus = e;
        switch (e)
        {
            case wndStatus.wndClose:
                OnClose();
                break;
            case wndStatus.wndOpen:
                OnOpen();
                break;
        }
    }
    /// <summary>
    /// 打开/关闭窗口
    /// </summary>
    public virtual void SwitchWnd()
    {
        if (IsOpen())
        {
            CloseWnd();
        }
        else if (IsClose())
        {
            OpenWnd();
        }
    }
    /// <summary>
    /// 关闭窗口
    /// </summary>
    public virtual void CloseWnd()
    {

        //if (!string.Equals(m_strWndName, "HUD") && DicWnd["HUD"].IsOpen())
        //{
        //    ((HUD)UIBaseWnd.GetWndByName("HUD")).ShowHUD(true);
        //}
        if (WndRootGameObject != null)
        {
            GameObject.Destroy(WndRootGameObject);
            SetWndStatus(wndStatus.wndClose);
        }
    }
    protected virtual void OnOpen()
    {
    }

    protected virtual void OnClose()
    {
    }
   
}
