using UnityEngine;
using System.Collections;

public class InfoWindowBtn : MonoBehaviour
{
    private Transform btn;
    private Transform closeBtn;
    private Transform InfoWnd;
    // Use this for initialization
    void Start()
    {
        btn = this.transform;
        InfoWnd = this.transform.parent.parent.parent.Find("InfoWnd");
        closeBtn = InfoWnd.Find("Close");
        InfoWnd.gameObject.SetActive(false);
        AddEvent();
    }

    private void AddEvent()
    {
        UIEventListener.Get(btn.gameObject).onClick = OnInfoBtn;
        UIEventListener.Get(closeBtn.gameObject).onClick = OnCloseBtn;
    }

    private void OnCloseBtn(GameObject go)
    {
        InfoWnd.gameObject.SetActive(false);
    }

    private void OnInfoBtn(GameObject go)
    {
        InfoWnd.gameObject.SetActive(true);
        if (Application.loadedLevelName == "Start")
        {
            GameApp.SetText(InfoWnd.Find("Title").transform,2);
            GameApp.SetText(InfoWnd.Find("Content").transform, 3);
            GameApp.SetText(InfoWnd.Find("Name").transform, 4);
        }
        else if (Application.loadedLevelName == "MainScene")
        {
            GameApp.SetText(InfoWnd.Find("Title").transform, 11);
            GameApp.SetText(InfoWnd.Find("Content").transform, 12);
            GameApp.SetText(InfoWnd.Find("Name").transform, 4);
        }
    }

    // Update is called once per frame
    void Update()
    {

    }
}
