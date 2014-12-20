using UnityEngine;
using System.Collections;

public class GameApp:MonoBehaviour {
    public static GameObject gameApp;
    private static GameApp m_Instance;
    public static LanguageType curLanguage;
    private GameApp()
    {
        if (m_Instance != null)
        {
            Debug.Log("There is already an instance of GameApp");
            return;
        }
        m_Instance = this;
    }
    public static void Init()
    {
        if (Application.isPlaying)
        {
            gameApp = new GameObject("gameapp");
            Object.DontDestroyOnLoad(gameApp.transform);
            gameApp.AddComponent<GameApp>();
            int index = PlayerPrefs.GetInt("Language");
            switch (index)
            {
                case 0:
                    curLanguage = LanguageType.Chinese;
                    break;
                case 1:
                    curLanguage = LanguageType.Chinese;
                    break;
                case 2:
                    curLanguage = LanguageType.English;
                    break;
                case 3:
                    curLanguage = LanguageType.Japanese;
                    break;
            }
        }
    }
    internal static void SetText(Transform transform, int ID)
    {
        if (curLanguage == LanguageType.Chinese)
        {
            transform.GetComponent<UILabel>().font = ResourceLoad.GetInstance().xjlFont;
            transform.GetComponent<UILabel>().text = TableLanguage.GetInstance().GetTextById(ID, curLanguage);
        }
        else if (curLanguage == LanguageType.English)
        {
            transform.GetComponent<UILabel>().font = ResourceLoad.GetInstance().xjlFont;
            transform.GetComponent<UILabel>().text = TableLanguage.GetInstance().GetTextById(ID, curLanguage);
        }
        else if (curLanguage == LanguageType.Japanese)
        {
            transform.GetComponent<UILabel>().font = ResourceLoad.GetInstance().jpFont;
            transform.GetComponent<UILabel>().text = TableLanguage.GetInstance().GetTextById(ID, curLanguage);
        }
    }
    internal static void SetText(Transform transform, int ID,LanguageType type)
    {
        if (type == LanguageType.Chinese)
        {
            transform.GetComponent<UILabel>().font = ResourceLoad.GetInstance().xjlFont;
            transform.GetComponent<UILabel>().text = TableLanguage.GetInstance().GetTextById(ID, type);
        }
        else if (type == LanguageType.English)
        {
            transform.GetComponent<UILabel>().font = ResourceLoad.GetInstance().xjlFont;
            transform.GetComponent<UILabel>().text = TableLanguage.GetInstance().GetTextById(ID, type);
        }
        else if (type == LanguageType.Japanese)
        {
            transform.GetComponent<UILabel>().font = ResourceLoad.GetInstance().jpFont;
            transform.GetComponent<UILabel>().text = TableLanguage.GetInstance().GetTextById(ID, type);
        }
    }
}
