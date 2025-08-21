using System.Collections;
using UnityEngine;

public class ManegeScript_Object : MonoBehaviour
{
    public int pictureID;

    public bool getted = false;
    bool clockUpDown = false;
    public bool gettedSwitch = false;

    public float scrollSpeed_obj;
    public float deathPos;

    public float upDownSpeed;
    public float upDownWait;
    float upDown;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(upDownSwitch());
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(-1 * scrollSpeed_obj * Time.deltaTime, upDown, 0);

        if (clockUpDown == false)
        {
            upDown = -1 * upDownSpeed * Time.deltaTime;
        }
        else
        {
            upDown = 1 * upDownSpeed * Time.deltaTime;
        }
        
        if (transform.position.x <= deathPos) Destroy(gameObject);

        if (getted == true && gettedSwitch == true)
        {
            decreaseFinder();
        }

        if (gettedSwitch == true)
        {
            gettedSwitch = false;
        }

    }

    void decreaseFinder()
    {
        ControlScript_Finder.finders--;
        return;
    }

    IEnumerator upDownSwitch()
    {
        while (true)
        {
            yield return new WaitForSeconds(upDownWait);

            if (clockUpDown == false)
            {
                clockUpDown = true;
            }
            else
            {
                clockUpDown = false;
            }
        }
    }
}
