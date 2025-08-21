using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SceneScript_Result : MonoBehaviour
{
    public Text score;
    public GameObject NextButton;
    public AudioClip startSound;
    public AudioClip finishSound;
    public AudioClip[] resultSound;

    AudioSource audioSource;

    public RectTransform resultText;
    public RectTransform scoreText;

    public GameObject[] stars;

    public SceneAsset[] nextStages;
    public SceneAsset LastScene;

    bool finish;

    public static int scoreCalculations,tutorialScore, Score01, Score02, Score03, LastScore;
    public static Sprite selectPic01, selectPic02, selectPic03;

    public CreateScript_PhotoData[] pictureDateBase;
    public Image resultPic;
    public Text nameTitle;

    public ParticleSystem effect;

    public GameObject Tutorial;
    public Text TutorialText;

    public GameObject comment;

    // Start is called before the first frame update
    void Start()
    {
        if (ManegeScript_Name.playerName.text == "")
        {
            nameTitle.text = "匿名さんの反応数は…";
        }
        else
        {
            nameTitle.text = ManegeScript_Name.playerName.text + "さんの反応数は…";
        }

        NextButton.SetActive(false);

        audioSource = GetComponent<AudioSource>();
        score = score.GetComponent<Text>();

        finish = false;

        for(int d = 0; d < stars.Length; d++)
        {
            stars[d].SetActive(false);
        }

        StartCoroutine(ResultOpen());

        SceneManager.sceneUnloaded += SceneUnloaded;

        if(ControlScript_Finder.stageStates == Stage.Tutorial)
        {
            Tutorial.SetActive(true);
            comment.SetActive(false);
        }
        else
        {
            comment.SetActive(true);
            Tutorial.SetActive(false);
        }
    }

    void Awake()
    {
        if (ControlScript_Finder.stageStates == Stage.Tutorial)
        {
            tutorialScore = ScoreCalculation();
            score.text = "反応数 : " + tutorialScore;

            resultPic.sprite = SceneScript_Select.selectPic.picture;
        }

        if (ControlScript_Finder.stageStates == Stage.Game01)
        {
            Score01 = ScoreCalculation();
            score.text = "反応数 : " + Score01;

            resultPic.sprite = SceneScript_Select.selectPic.picture;
            selectPic01 = SceneScript_Select.selectPic.picture;
        }

        if (ControlScript_Finder.stageStates == Stage.Game02)
        {
            Score02 = ScoreCalculation();
            score.text = "反応数 : " + Score02;

            resultPic.sprite = SceneScript_Select.selectPic.picture;
            selectPic02 = SceneScript_Select.selectPic.picture;
        }

        if (ControlScript_Finder.stageStates == Stage.Game03)
        {
            Score03 = ScoreCalculation();
            score.text = "反応数 : " + Score03;

            resultPic.sprite = SceneScript_Select.selectPic.picture;
            selectPic03 = SceneScript_Select.selectPic.picture;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if(finish == true)
        {
            NextButton.SetActive(false);
        }
    }

    public void IsNext()
    {
        if(ControlScript_Finder.stageStates == Stage.Tutorial)
        {
            GameObject.Find("FadeOutCanvas").GetComponent<ManegeScript_FadeOut>().nextScene = nextStages[0];
            GameObject.Find("FadeOutCanvas").GetComponent<ManegeScript_FadeOut>().SendMessage("StartCor");
        }else if(ControlScript_Finder.stageStates == Stage.Game01)
        {
            GameObject.Find("FadeOutCanvas").GetComponent<ManegeScript_FadeOut>().nextScene = nextStages[1];
            GameObject.Find("FadeOutCanvas").GetComponent<ManegeScript_FadeOut>().SendMessage("StartCor");
        }else if(ControlScript_Finder.stageStates == Stage.Game02)
        {
            GameObject.Find("FadeOutCanvas").GetComponent<ManegeScript_FadeOut>().nextScene = nextStages[2];
            GameObject.Find("FadeOutCanvas").GetComponent<ManegeScript_FadeOut>().SendMessage("StartCor");
        }else if(ControlScript_Finder.stageStates == Stage.Game03)
        {
            GameObject.Find("FadeOutCanvas").GetComponent<ManegeScript_FadeOut>().nextScene = LastScene;
            GameObject.Find("FadeOutCanvas").GetComponent<ManegeScript_FadeOut>().SendMessage("StartCor");
        }

        if (ControlScript_Finder.stageStates == Stage.Tutorial)
        {
            TutorialText.text = "いってらっしゃい！未来のバズッチャー！にゃ！";
        }

        finish = true;
    }

    IEnumerator ResultOpen()
    {
        Vector3 startPos0 = resultText.localPosition;
        Vector3 endPos0 = new Vector3(360.0f, startPos0.y, startPos0.z);
        float animationDuration0 = 0.9f;
        float startTime0 = Time.time;

        while(Time.time - startTime0 < animationDuration0)
        {
            float fraction0 = ((Time.time - startTime0) / animationDuration0);
            fraction0 = Mathf.SmoothStep(0.0f, 0.55f, fraction0);
            resultText.localPosition = Vector3.Lerp(startPos0, endPos0, fraction0);

            yield return null;
        }

        audioSource.PlayOneShot(resultSound[0]);

        yield return new WaitForSeconds(animationDuration0);

        Vector3 startPos1 = scoreText.localPosition;
        Vector3 endPos1 = new Vector3(360.0f, startPos1.y, startPos1.z);
        float animationDuration1 = 1.2f;
        float startTime1 = Time.time;

        while (Time.time - startTime1 < animationDuration1)
        {
            float fraction1 = ((Time.time - startTime1) / animationDuration1);
            fraction1 = Mathf.SmoothStep(0.0f, 0.55f, fraction1);
            scoreText.localPosition = Vector3.Lerp(startPos1, endPos1, fraction1);

            yield return null;
        }

        effect.Play();
        audioSource.PlayOneShot(resultSound[1]);

        yield return new WaitForSeconds(animationDuration1);

        if(SceneScript_Select.selectPic.rarerity == Rarerity.o)
        {
            audioSource.PlayOneShot(resultSound[2]);
            stars[0].SetActive(true);
        }

        if (SceneScript_Select.selectPic.rarerity == Rarerity.oo)
        {
            audioSource.PlayOneShot(resultSound[2]);
            stars[0].SetActive(true);

            yield return new WaitForSeconds(0.2f);

            audioSource.PlayOneShot(resultSound[2]);
            stars[1].SetActive(true);
        }

        if (SceneScript_Select.selectPic.rarerity == Rarerity.ooo)
        {
            audioSource.PlayOneShot(resultSound[2]);
            stars[0].SetActive(true);

            yield return new WaitForSeconds(0.2f);

            audioSource.PlayOneShot(resultSound[2]);
            stars[1].SetActive(true);

            yield return new WaitForSeconds(0.2f);

            audioSource.PlayOneShot(resultSound[2]);
            stars[2].SetActive(true);
        }

        yield return null;

        NextButton.SetActive(true);
    }

    int ScoreCalculation()
    {
        if (SceneScript_Select.selectPic.rarerity == Rarerity.o)
        {
            scoreCalculations = Random.Range(100, 1000);
        }

        if (SceneScript_Select.selectPic.rarerity == Rarerity.oo)
        {
            scoreCalculations = Random.Range(1001, 10000);
        }

        if (SceneScript_Select.selectPic.rarerity == Rarerity.ooo)
        {
            scoreCalculations = Random.Range(10000, 30000);
        }

        if(SceneScript_Select.selectPic == null)
        {
            scoreCalculations = 0;
        }

        return scoreCalculations;
    }

    void SceneUnloaded(Scene thisScene)
    {
        ControlScript_PlayerData.playerfolder.Clear();
    }
}
