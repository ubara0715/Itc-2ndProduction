using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ManegeScript_Name : MonoBehaviour
{
    public InputField inputField;
    public static Text playerName;
    public static string playerName2;

    // Start is called before the first frame update
    void Start()
    {
        Cursor.visible = true;
        inputField = inputField.GetComponent<InputField>();
        playerName = GameObject.FindWithTag("Name").GetComponent<Text>();
    }

    public void InputText()
    {
        playerName.text = inputField.text;
    }

    // Update is called once per frame
    void Update()
    {
        playerName2 = playerName.text;
    }
}
