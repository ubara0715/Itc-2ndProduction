using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEditor.SearchService;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SceneScript_Select : MonoBehaviour
{
    public SceneAsset resultScene;
    public AudioClip nextSound;
    AudioSource audioSource;
    public CreateScript_PhotoData[] pictureDateBase;
    public static CreateScript_PhotoData thisSceneData;

    public Image fadeImage;
    public Text fadeText;
    float fadeoutSpeed = 2.0f;
    bool IsFade = false;

    [SerializeField] Image monitor;
    public static PhotoInformation selectPic = null;

    public Text nameText;

    public GameObject[] buttons;
    public Image[] buttonsImage;

    public GameObject nextButton;

    public GameObject Tutorial;

    // Start is called before the first frame update
    void Start()
    {
        Cursor.visible = true;

        if(ControlScript_Finder.stageStates == Stage.Tutorial)
        {
            Tutorial.SetActive(true);
        }
        else
        {
            Tutorial.SetActive(false);
        }

        if (ManegeScript_Name.playerName.text == "")
        {
            nameText.text = "“½–¼‚³‚ñ";
        }
        else
        {
            nameText.text = ManegeScript_Name.playerName.text;
        }

        if (ControlScript_Finder.stageStates == Stage.Tutorial)
        {
            thisSceneData = pictureDateBase[0];
        }
        else if(ControlScript_Finder.stageStates == Stage.Game01)
        {
            thisSceneData = pictureDateBase[1];
        }
        else if(ControlScript_Finder.stageStates == Stage.Game02)
        {
            thisSceneData = pictureDateBase[2];
        }
        else
        {
            thisSceneData = pictureDateBase[3];
        }

        audioSource = GetComponent<AudioSource>();
        fadeImage = fadeImage.GetComponent<Image>();
        fadeText = fadeText.GetComponent<Text>();

        nextButton.SetActive(false);

        for (int i = 0; i < ControlScript_PlayerData.playerfolder.Count; i++)
        {
            buttons[i].SetActive(true);
            buttonsImage[i].sprite = thisSceneData.pictureInfos[ControlScript_PlayerData.playerfolder[i]].picture;
        }
    }

    void Awake()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(!(monitor.sprite == null))
        {
            nextButton.SetActive(true);
        }
    }

    public void OnNext()
    {
        if(IsFade == false)
        {
            StartCoroutine(FadeOutScene());
        }
    }

    public void SelectButton(int n)
    {
        if(ControlScript_PlayerData.playerfolder.Count > 0)
        {
            selectPic = thisSceneData.pictureInfos[ControlScript_PlayerData.playerfolder[n]];
            monitor.sprite = selectPic.picture;
        }
        else
        {
            monitor = null;
        }
    }


    IEnumerator FadeOutScene()
    {
        IsFade = true;

        audioSource.PlayOneShot(nextSound);

        fadeImage.enabled = true;
        fadeText.enabled = true;
        float elapsedTime = 0.0f;
        Color sCI = fadeImage.color;
        Color sCT = fadeText.color;
        Color eCI = new Color(sCI.r, sCI.b, sCI.g, 1.0f);
        Color eCT = new Color(sCT.r, sCT.b, sCT.g, 1.0f);

        while (elapsedTime < fadeoutSpeed)
        {
            elapsedTime += Time.deltaTime;
            float t = Mathf.Clamp01(elapsedTime / fadeoutSpeed);
            fadeImage.color = Color.Lerp(sCI, eCI, t);
            fadeText.color = Color.Lerp(sCT, eCT, t + 0.01f);
            yield return null;
        }

        IsFade = false;

        yield return new WaitForSeconds(0.5f);

        GameObject.Find("FadeOutCanvas").GetComponent<ManegeScript_FadeOut>().SendMessage("StartCor");
    }
}
