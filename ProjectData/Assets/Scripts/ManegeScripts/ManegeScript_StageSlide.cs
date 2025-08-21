using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ManegeScript_StageSlide : MonoBehaviour
{
    public float stageSpeed;
    public float endPos;
    ManegeScript_StageGenerator generator;

    // Start is called before the first frame update
    void Start()
    {
        generator = GameObject.Find("Generator").GetComponent<ManegeScript_StageGenerator>();
    }

    // Update is called once per frame
    void Update()
    {
        if(generator.IsStartAnima == true)
        {
            transform.Translate(-1 * stageSpeed * Time.deltaTime, 0, 0);

            if (transform.position.x <= endPos)
            {
                gameObject.SetActive(false);
            }
        }

        if(gameObject.activeSelf == false)
        {
            generator.SendMessage("StageGenerate");
        }
    }
}
