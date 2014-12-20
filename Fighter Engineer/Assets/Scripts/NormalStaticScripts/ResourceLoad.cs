using UnityEngine;
using System.Collections;

public class ResourceLoad
{
    public static ResourceLoad instance = null;
    public UIFont xjlFont;
    public UIFont jpFont;
    public UIAtlas BackgroundAtlas;
    public UIAtlas EnemyAtlas;
    public UIAtlas PartsAtlas;
    public UIAtlas UiAtlas;
    public static ResourceLoad GetInstance()
    {
        if (instance == null)
        {
            instance=new ResourceLoad();
        }
        return instance;
    }

    public void Load()
    {
        TableAchievement.GetInstance().Read();
        TableEnemy.GetInstance().Read();
        TableLanguage.GetInstance().Read();
        TableParts.GetInstance().Read();
       xjlFont =Resources.Load<UIFont>("Font/xjlFont");
       jpFont = Resources.Load<UIFont>("Font/jpFont");
        BackgroundAtlas = Resources.Load<UIAtlas>("Background/Background");
        EnemyAtlas = Resources.Load<UIAtlas>("Enemy/Enemy");
        PartsAtlas = Resources.Load<UIAtlas>("Parts/Parts");
        UiAtlas = Resources.Load<UIAtlas>("UI/UI");
        Debug.Log("ResourceLoadDone!");
    } 
}
