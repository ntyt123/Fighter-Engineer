using UnityEngine;
using System.Collections;

public class SetLanguage : MonoBehaviour
{
    public int ID;
    // Use this for initialization
    void Start()
    {
       GameApp.SetText(this.transform,ID);
    }

    // Update is called once per frame
    void Update()
    {

    }
}
