using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ManegeScript_ScrollerVertical : MonoBehaviour
{
    public float scrollSpeedV;
    Vector2 startPosV = new Vector2(0, -480);
    Vector2 endPosV = new Vector2(0, 360);

    RectTransform rectTransform;

    // Start is called before the first frame update
    void Start()
    {
        rectTransform = GetComponent<RectTransform>();
    }

    // Update is called once per frame
    void Update()
    {
        rectTransform.Translate(0, 1 * scrollSpeedV * Time.deltaTime, 0);

        if (rectTransform.localPosition.y >= endPosV.y) ScrollEnd();
    }

    void ScrollEnd()
    {
        rectTransform.localPosition = startPosV;
    }
}
