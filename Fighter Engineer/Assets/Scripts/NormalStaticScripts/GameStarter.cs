using UnityEngine;
using System.Collections;

public class GameStarter : MonoBehaviour {
    void Awake()
    {
        ResourceLoad.GetInstance().Load();
        GameApp.Init();
        GameObject.DontDestroyOnLoad(this.gameObject);
    }
	// Use this for initialization
	void Start () {
       
	}
	
	// Update is called once per frame
	void Update () {
	}
}
