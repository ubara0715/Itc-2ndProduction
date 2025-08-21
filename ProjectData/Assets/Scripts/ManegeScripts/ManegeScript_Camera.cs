using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ManegeScript_Camera : MonoBehaviour
{
    bool clockUpDownC = false;

    public float upDownSpeedC;
    public float upDownWaitC;
    float upDownC;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(upDownSwitchC());
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(0, upDownC, 0);

        if (clockUpDownC == false)
        {
            upDownC = -1 * upDownSpeedC * Time.deltaTime;
        }
        else
        {
            upDownC = 1 * upDownSpeedC * Time.deltaTime;
        }
    }

    IEnumerator upDownSwitchC()
    {
        while (true)
        {
            yield return new WaitForSeconds(upDownWaitC);

            if (clockUpDownC == false)
            {
                clockUpDownC = true;
            }
            else
            {
                clockUpDownC = false;
            }
        }
    }
}
