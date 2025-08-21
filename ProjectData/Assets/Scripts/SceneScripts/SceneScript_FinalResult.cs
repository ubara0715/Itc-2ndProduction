using System.Collections;
using System.Collections.Generic;
using System.Xml;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SceneScript_FinalResult : MonoBehaviour
{
    public Text[] allText;
    public Image[] selectedPics;

    public GameObject nextButton;

    public AudioClip[] sounds;
    AudioSource audioSource;

    public ParticleSystem effect;

    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>();

        SceneManager.sceneUnloaded += UnLoadScene;

        for(int i = 1; i < allText.Length; i++)
        {
            allText[i].text = "";
        }

        nextButton.SetActive(false);

        if(!(SceneScript_Result.selectPic01 == null))
        {
            selectedPics[0].sprite = SceneScript_Result.selectPic01;
            selectedPics[1].sprite = SceneScript_Result.selectPic02;
            selectedPics[2].sprite = SceneScript_Result.selectPic03;
        }
        else
        {
            selectedPics[0].sprite = null;
            selectedPics[1].sprite = null;
            selectedPics[2].sprite = null;
        }

        StartCoroutine(ScoreAnnouncement());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator ScoreAnnouncement()
    {
        if (ManegeScript_Name.playerName.text == "")
        {
            allText[0].text = "��������̃o�Y��́c�H";
        }
        else
        {
            allText[0].text = ManegeScript_Name.playerName.text + "����̃o�Y��́c�H";
        }

        yield return new WaitForSeconds(0.7f);

        audioSource.PlayOneShot(sounds[1]);

        if (!(SceneScript_Result.Score01 == 0))
        {
            allText[1].text = "�X : " + SceneScript_Result.Score01;
        }
        else
        {
            allText[1].text = "���ʂȂ񂩂˂���";
        }
        
        yield return new WaitForSeconds(0.7f);

        audioSource.PlayOneShot(sounds[1]);

        if (!(SceneScript_Result.Score02 == 0))
        {
            allText[2].text = "�X : " + SceneScript_Result.Score02;
        }
        else
        {
            allText[2].text = "���ʂȂ񂩂˂���";
        }

        yield return new WaitForSeconds(0.7f);

        audioSource.PlayOneShot(sounds[1]);

        if (!(SceneScript_Result.Score03 == 0))
        {
            allText[3].text = "�C : " + SceneScript_Result.Score03;
        }
        else
        {
            allText[3].text = "���ʂȂ񂩂˂���";
        }

        yield return new WaitForSeconds(1.4f);

        effect.Play();
        audioSource.PlayOneShot(sounds[2]);

        if (!(SceneScript_Result.Score01 == 0))
        {
            int finalScore = SceneScript_Result.Score01 + SceneScript_Result.Score02 + SceneScript_Result.Score03;
            allText[4].text = "���� : " + finalScore;
        }
        else
        {
            allText[4].text = "���ʂȂ񂩂˂���΁[���I�I�I";
        }

        yield return new WaitForSeconds(0.6f);

        nextButton.SetActive(true);
    }

    public void IsStartBuck()
    {
        audioSource.PlayOneShot(sounds[3]);
        GameObject.Find("FadeOutCanvas").GetComponent<ManegeScript_FadeOut>().SendMessage("StartCor");
    }

    void UnLoadScene(Scene thisScene)
    {
        ControlScript_PlayerData.playerfolder.Clear();
        ControlScript_Finder.finders = 0;
        SceneScript_Result.selectPic01 = null;
        SceneScript_Result.selectPic02 = null;
        SceneScript_Result.selectPic03 = null;
        SceneScript_Result.Score01 = 0;
        SceneScript_Result.Score02 = 0;
        SceneScript_Result.Score03 = 0;
        ManegeScript_Name.playerName = null;
        ManegeScript_Name.playerName2 = null;

        Destroy(GameObject.Find("finderMng").gameObject);
    }
}
