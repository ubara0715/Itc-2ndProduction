using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ManegeScript_TutorialButton : MonoBehaviour
{
    public string boolOn;
    public GameObject StateMng;
    SceneScript_Tutorial tutorial_01;

    // Start is called before the first frame update
    void Start()
    {
        tutorial_01 = StateMng.GetComponent<SceneScript_Tutorial>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnClick()
    {
        tutorial_01.SendMessage(boolOn);
    }
}
