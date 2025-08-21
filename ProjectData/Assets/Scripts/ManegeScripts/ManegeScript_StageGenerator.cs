using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class ManegeScript_StageGenerator : MonoBehaviour
{
    public GameObject[] Stages;

    public Image fadeImage;
    public float fadeSpeed;

    public GameObject[] Pins;
    public GameObject playerImage;
    RectTransform playerPos;

    public float playerAnima;

    Vector2 Pos01 = new Vector2(-330.0f, -80);
    Vector2 Pos02 = new Vector2(0.0f, -80);
    Vector2 Pos03 = new Vector2(330.0f, -80);

    public AudioClip PinsSound;
    AudioSource audioSource;

    public bool IsStartAnima = false;

    public GameObject[] OffObj;

    public Image fadeImage02;
    public Text fadeText;
    float fadeoutSpeed = 2.0f;

    public Sprite[] StageSelect;

    int i = 1;

    // Start is called before the first frame update
    void Start()
    {
        playerPos = playerImage.GetComponent<RectTransform>();
        audioSource = GetComponent<AudioSource>();

        for (int q = 0; q < Pins.Length; q++)
        {
            Pins[q].SetActive(false);
        }

        playerImage.SetActive(false);

        for (int q = 0; q < OffObj.Length; q++)
        {
            OffObj[q].SetActive(false);
        }

        if(ControlScript_Finder.stageStates == Stage.Game01)
        {
            fadeImage.sprite = StageSelect[0];
        }
        else if(ControlScript_Finder.stageStates == Stage.Game02)
        {
            fadeImage.sprite = StageSelect[1];
        }
        else
        {
            fadeImage.sprite = StageSelect[2];
        }

        StartCoroutine(StageStart());
    }

    // Update is called once per frame
    void Update()
    {
        if (ControlScript_Finder.finders == 0)
        {
            StartOn();
        }
    }

    public void StageGenerate()
    {
        i++;

        Instantiate(
            Stages[i],
            transform.position,
            Quaternion.identity
            );

        if (i == Stages.Length -1)
        {
            Invoke(nameof(StartOn), 18.0f);
        }
    }

    IEnumerator StageStart()
    {
        Color sCIOut = fadeImage.color;
        Color eCIOut = new Color(sCIOut.r, sCIOut.b, sCIOut.g, 0.7f);
        fadeImage.enabled = true;
        float elapsedTimeOut = 0.0f;

        while (elapsedTimeOut < fadeSpeed)
        {
            elapsedTimeOut += Time.deltaTime;
            float tOut = Mathf.Clamp01(elapsedTimeOut / fadeSpeed);
            fadeImage.color = Color.Lerp(sCIOut, eCIOut, tOut);
            yield return null;
        }

        yield return null;

        audioSource.PlayOneShot(PinsSound);

        for(int index = 0; index < Pins.Length; index++)
        {
            Pins[index].SetActive(true);
        }

        playerImage.SetActive(true);

        if(ControlScript_Finder.stageStates == Stage.Game01)
        {
            playerPos.anchoredPosition = Pos01;
        }

        if(ControlScript_Finder.stageStates == Stage.Game02)
        {
            playerPos.anchoredPosition = Pos01;
        }

        if(ControlScript_Finder.stageStates == Stage.Game03)
        {
            playerPos.anchoredPosition = Pos02;
        }

        yield return null;

        float animaTime = 0.0f;

        if(ControlScript_Finder.stageStates == Stage.Game02 || ControlScript_Finder.stageStates == Stage.Game03)
        {
            while (playerAnima > animaTime)
            {
                yield return null;

                animaTime += 0.004f;
                playerPos.position += new Vector3(0.79f, 0.0f, 0.0f);
            }
        }

        yield return new WaitForSeconds(2.0f);

        Color sCI0 = Pins[0].GetComponent<Image>().color;
        Color eCI0 = new Color(sCI0.r, sCI0.b, sCI0.g, 0.0f);
        float elapsedTime0 = 0.0f;

        while (elapsedTime0 < fadeSpeed)
        {
            elapsedTime0 += Time.deltaTime;
            float t0 = Mathf.Clamp01(elapsedTime0 / fadeSpeed);
            Pins[0].GetComponent<Image>().color = Color.Lerp(sCI0, eCI0, t0);
            yield return null;
        }

        Color sCI1 = Pins[1].GetComponent<Image>().color;
        Color eCI1 = new Color(sCI1.r, sCI1.b, sCI1.g, 0.0f);
        float elapsedTime1 = 0.0f;

        while (elapsedTime1 < fadeSpeed)
        {
            elapsedTime1 += Time.deltaTime;
            float t1 = Mathf.Clamp01(elapsedTime1 / fadeSpeed);
            Pins[1].GetComponent<Image>().color = Color.Lerp(sCI1, eCI1, t1);
            yield return null;
        }

        Color sCI2 = Pins[2].GetComponent<Image>().color;
        Color eCI2 = new Color(sCI2.r, sCI2.b, sCI2.g, 0.0f);
        float elapsedTime2 = 0.0f;

        while (elapsedTime2 < fadeSpeed)
        {
            elapsedTime2 += Time.deltaTime;
            float t2 = Mathf.Clamp01(elapsedTime2 / fadeSpeed);
            Pins[2].GetComponent<Image>().color = Color.Lerp(sCI2, eCI2, t2);
            yield return null;
        }

        Color sCI = playerImage.GetComponent<Image>().color;
        Color eCI = new Color(sCI.r, sCI.b, sCI.g, 0.0f);
        float elapsedTime = 0.0f;

        while (elapsedTime < fadeSpeed)
        {
            elapsedTime += Time.deltaTime;
            float t = Mathf.Clamp01(elapsedTime / fadeSpeed);
            playerImage.GetComponent<Image>().color = Color.Lerp(sCI, eCI, t);
            yield return null;
        }

        yield return null;

        Color sCIIn = fadeImage.color;
        Color eCIIn = new Color(sCIIn.r, sCIIn.b, sCIIn.g, 0.0f);
        float elapsedTimeIn = 0.0f;

        while (elapsedTimeIn < fadeSpeed)
        {
            elapsedTimeIn += Time.deltaTime;
            float tIn = Mathf.Clamp01(elapsedTimeIn / fadeSpeed);
            fadeImage.color = Color.Lerp(sCIIn, eCIIn, tIn);
            yield return null;
        }

        fadeImage.enabled = false;
        IsStartAnima = true;

        for (int q = 0; q < OffObj.Length; q++)
        {
            OffObj[q].SetActive(true);
        }
    }

    IEnumerator StageFinishFade()
    {
        fadeImage02.enabled = true;
        fadeText.enabled = true;
        float elapsedTime02 = 0.0f;
        Color sCI02 = fadeImage02.color;
        Color sCT = fadeText.color;
        Color eCI02 = new Color(sCI02.r, sCI02.b, sCI02.g, 1.0f);
        Color eCT = new Color(sCT.r, sCT.b, sCT.g, 1.0f);

        while (elapsedTime02 < fadeoutSpeed)
        {
            elapsedTime02 += Time.deltaTime;
            float t02 = Mathf.Clamp01(elapsedTime02 / fadeoutSpeed);
            fadeImage02.color = Color.Lerp(sCI02, eCI02, t02);
            fadeText.color = Color.Lerp(sCT, eCT, t02 + 0.01f);
            yield return null;
        }

        yield return new WaitForSeconds(1.0f);

        GameObject.Find("FadeOutCanvas").GetComponent<ManegeScript_FadeOut>().SendMessage("StartCor");
    }

    public void StartOn()
    {
        StartCoroutine(StageFinishFade());

        return;
    }
}
