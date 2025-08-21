using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public enum Stage
{
    Tutorial,
    Game01,
    Game02,
    Game03
}

public class ControlScript_Finder : MonoBehaviour
{
    //ファインダー制御
    Vector3 mousePos;
    float mousePosV, mousePosH;

    //ファインダー枚数管理
    public static int finders;
    public int giftFinder;

    //クリック制御
    string colObj;
    string colObjX;
    int index;
    public float clickCoolTime;
    bool coolTimeSwicth = true;

    Collider2D col2D;

    List<string> colObjList = new List<string>();

    //予備の写真
    public int spare;

    public Text FinderText;
    public AudioClip shutterSound;
    AudioSource audioSource;

    public static Stage stageStates;
    public Stage stage;

    // Start is called before the first frame update
    void Start()
    {
        Cursor.visible = false;

        //ファインダー枚数管理
        finders += giftFinder;

        //予備
        SceneManager.sceneUnloaded += SceneUnloaded;

        audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        stageStates = stage;

        //ファインダー制御
        mousePosV = Input.mousePosition.x;
        mousePosH = Input.mousePosition.y;
        mousePos = Camera.main.ScreenToWorldPoint(new Vector3(mousePosV, mousePosH, 10.0f));
        transform.position = mousePos;

        FinderText.text = "残り " + finders + "枚";
    }

    void SceneUnloaded(Scene thisScene)
    {
        if (!(ControlScript_PlayerData.playerfolder.Count > 0))
        {
            ControlScript_PlayerData.playerfolder.Add(0);
        }
        else
        {
            ControlScript_PlayerData.playerfolder = new List<int> (ControlScript_PlayerData.playerfolder);
        }

        if(stage == Stage.Tutorial)
        {
            finders = 0;
        }
    }

    IEnumerator finderCoolTime()
    {
        coolTimeSwicth = false;

        yield return new WaitForSeconds(clickCoolTime);
        Debug.Log("撮れるよ");
        coolTimeSwicth = true;
    }

    private void OnTriggerStay2D(Collider2D col)
    {
        if(finders >= 1)
        {
            if (col.gameObject.GetComponent<ManegeScript_Object>())
            {
                if (col.GetComponent<ManegeScript_Object>().getted == false)
                {
                    colObj = col.gameObject.name;
                }

                if (col.GetComponent<ManegeScript_Object>().getted == true)
                {
                    colObjX = col.gameObject.name;
                }

                if (!colObjList.Contains(colObj))
                {
                    if (col.GetComponent<ManegeScript_Object>().getted == false)
                    {
                        colObjList.Add(colObj);
                    }
                }

                colObjList.Remove(colObjX);
            }

            if (coolTimeSwicth == true)
            {
                if (Input.GetMouseButton(0))
                {
                    if (colObjList.Count >= 1)
                    {
                        audioSource.PlayOneShot(shutterSound);

                        index = Random.Range(0, colObjList.Count - 1);

                        GameObject addListObj = GameObject.Find(colObjList[index]);
                        addListObj.GetComponent<ManegeScript_Object>().getted = true;
                        addListObj.GetComponent<ManegeScript_Object>().gettedSwitch = true;

                        ControlScript_PlayerData.playerfolder.Add(addListObj.GetComponent<ManegeScript_Object>().pictureID);

                        StartCoroutine(finderCoolTime());
                    }
                }
            }
        }
    }

    private void OnTriggerExit2D(Collider2D col)
    {
        colObjList.Remove(col.name);
    }
}
