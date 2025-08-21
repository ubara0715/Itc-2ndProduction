using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ManegeScript_ScrollHorizontal : MonoBehaviour
{
    public float scrollSpeed_alter;
    public float startPos_alter;
    public float endPos_alter;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    void Update()
    {
        transform.Translate(1 * scrollSpeed_alter * Time.deltaTime, 0, 0);

        if (transform.position.x >= endPos_alter) ScrollEnd();
    }

    void ScrollEnd()
    {
        float diff_alter = transform.position.x - endPos_alter;
        Vector3 restartPos_alter = transform.position;
        restartPos_alter.x = startPos_alter + diff_alter;
        transform.position = restartPos_alter;
    }
}
