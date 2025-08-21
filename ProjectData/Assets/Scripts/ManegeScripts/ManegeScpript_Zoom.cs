using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ManegeScpript_Zoom : MonoBehaviour
{
    bool clockZoom = false;

    public float ZoomSpeed;
    public float ZoomWait;
    Vector2 Zoom;

    RectTransform rectTransform;

    // Start is called before the first frame update
    void Start()
    {
        rectTransform = GetComponent<RectTransform>();
        Zoom = rectTransform.localScale;
    }

    // Update is called once per frame
    void Update()
    {
        rectTransform.localScale = Zoom;

        if (clockZoom == false)
        {
            Zoom.x += 1 * ZoomSpeed * Time.deltaTime;
            Zoom.y += 1 * ZoomSpeed * Time.deltaTime;
        }
        else
        {
            Zoom.x += -1 * ZoomSpeed * Time.deltaTime;
            Zoom.y += -1 * ZoomSpeed * Time.deltaTime;
        }
    }

    IEnumerator ZoomSwitch()
    {
        while (true)
        {
            yield return new WaitForSeconds(ZoomWait);

            if (clockZoom == false)
            {
                clockZoom = true;
            }
            else
            {
                clockZoom = false;
            }
        }
    }

    void OnEnable()
    {
        StartCoroutine(ZoomSwitch());
    }
}
