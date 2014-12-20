using UnityEngine;
using System.Collections;

public class OptionBtn : MonoBehaviour
{
    private Transform btn;
    private Transform optionWnd;
    private Transform closeBtn;
    private Transform okBtn;
    // Use this for initialization
    void Start()
    {
        btn = this.transform;
        optionWnd = this.transform.parent.parent.parent.Find("OptionWnd");
        closeBtn = optionWnd.Find("Close");
        okBtn = optionWnd.Find("OKBtn");
        optionWnd.gameObject.SetActive(false);
        AddEvent();
    }

    private void AddEvent()
    {
        UIEventListener.Get(btn.gameObject).onClick = OnBtn;
        UIEventListener.Get(closeBtn.gameObject).onClick = OnCloseBtn;
        UIEventListener.Get(okBtn.gameObject).onClick = OnOKBtn;
    }

    private void OnOKBtn(GameObject go)
    {
        string str = optionWnd.Find("LanguageSelect/CurLanguage").GetComponent<UILabel>().text;
        int index = 0;
        switch (str)
        {
            case "中文":
                GameApp.curLanguage = LanguageType.Chinese;
                index = 1;
                break;
                case "English":
                GameApp.curLanguage = LanguageType.English;
                index = 2;
                break;
                case "Japanese":
                GameApp.curLanguage = LanguageType.Japanese;
                index = 3;
                break;
        }
        PlayerPrefs.SetInt("Language",index);
        UILabel[] labelList = GameObject.Find("UI Root (3D)").GetComponentsInChildren<UILabel>();
        foreach (UILabel u in labelList)
        {
            if (u.transform.GetComponent<SetLanguage>())
            {
                GameApp.SetText(u.transform,TableLanguage.GetInstance().GetIdByText(u.text));
            }
        }
        optionWnd.gameObject.SetActive(false);
    }

    private void OnCloseBtn(GameObject go)
    {
        optionWnd.gameObject.SetActive(false);
    }

    private void OnBtn(GameObject go)
    {
        optionWnd.gameObject.SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {

    }
}
