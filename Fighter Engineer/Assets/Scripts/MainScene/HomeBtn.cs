using UnityEngine;
using System.Collections;

public class HomeBtn : MonoBehaviour
{
    private GameObject homeBtn;
	// Use this for initialization
	void Start ()
	{
	    homeBtn = this.gameObject;
	    AddEvent();
	}

    private void AddEvent()
    {
        UIEventListener.Get(homeBtn).onClick = OnHomeBtn;
    }

    private void OnHomeBtn(GameObject go)
    {
        Application.LoadLevel("Start");
    }
	
	// Update is called once per frame
	void Update () {
	
	}
}
