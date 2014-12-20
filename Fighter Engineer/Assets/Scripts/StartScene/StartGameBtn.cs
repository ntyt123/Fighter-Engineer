using UnityEngine;
using System.Collections;

public class StartGameBtn : MonoBehaviour
{
    private GameObject startGameBtn;
	// Use this for initialization
	void Start ()
	{
	    startGameBtn = this.gameObject;
	    UIEventListener.Get(startGameBtn).onClick = OnStartGameBtn;
	}

    private void OnStartGameBtn(GameObject go)
    {
       Application.LoadLevel("MainScene");
    }
	
}
