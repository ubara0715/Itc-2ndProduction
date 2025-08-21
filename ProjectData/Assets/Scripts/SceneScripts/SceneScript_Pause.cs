using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneScript_Pause : MonoBehaviour
{
    bool poseState;

    public GameObject[] mainUi;
    public GameObject poseUi;

    public GameObject[] restartButton;
    public GameObject[] titleButton;
    public GameObject[] quitButton;

    public AudioClip[] menuSounds;
    AudioSource audioSource;

    public GameObject skip;

    // Start is called before the first frame update
    void Start()
    {
        poseUi.SetActive(false);
        poseState = false;
        audioSource = GetComponent<AudioSource>();

        skip.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(1))
        {
            audioSource.PlayOneShot(menuSounds[0]);

            if(poseState == false)
            {
                poseState = true;
            }
            else
            {
                poseState = false;
            }
        }

        if(poseState == true)
        {
            Cursor.visible = true;
            Time.timeScale = 0;

            for(int index = 0; index < mainUi.Length; index++)
            {
                mainUi[index].SetActive(false);
            }

            poseUi.SetActive(true);
        }
        else
        {
            Time.timeScale = 1;

            for (int index = 0; index < mainUi.Length; index++)
            {
                mainUi[index].SetActive(true);
            }

            poseUi.SetActive(false);
        }
    }

    public void OnTurnBack()
    {
        audioSource.PlayOneShot(menuSounds[1]);
        poseState = false;
    }

    public void OnRestart()
    {
        audioSource.PlayOneShot(menuSounds[1]);
        restartButton[0].SetActive(false);
        restartButton[1].SetActive(true);
    }

    public void OnRestartTrue01()
    {
        audioSource.PlayOneShot(menuSounds[1]);
        SceneManager.LoadScene("GameScene01");
    }

    public void OnRestartTrue02()
    {
        audioSource.PlayOneShot(menuSounds[1]);
        SceneManager.LoadScene("GameScene02");
    }

    public void OnRestartTrue03()
    {
        audioSource.PlayOneShot(menuSounds[1]);
        SceneManager.LoadScene("GameScene03");
    }

    public void OnRestartTrue_tutorial()
    {
        audioSource.PlayOneShot(menuSounds[1]);
        SceneManager.LoadScene("Tutorial_main");
    }

    public void OnRestartFalse()
    {
        audioSource.PlayOneShot(menuSounds[1]);
        restartButton[0].SetActive(true);
        restartButton[1].SetActive(false);
    }

    public void OnTitle()
    {
        audioSource.PlayOneShot(menuSounds[1]);
        titleButton[0].SetActive(false);
        titleButton[1].SetActive(true);
    }

    public void OnTitleTure()
    {
        audioSource.PlayOneShot(menuSounds[1]);
        SceneManager.LoadScene("StartScene");
    }

    public void OnTitleFalse()
    {
        audioSource.PlayOneShot(menuSounds[1]);
        titleButton[0].SetActive(true);
        titleButton[1].SetActive(false);
    }

    public void OnQuit()
    {
        audioSource.PlayOneShot(menuSounds[1]);
        quitButton[0].SetActive(false);
        quitButton[1].SetActive(true);
    }

    public void OnQuitTure()
    {
        audioSource.PlayOneShot(menuSounds[1]);
        UnityEditor.EditorApplication.isPlaying = false;
        Application.Quit();
    }

    public void OnQuitFalse()
    {
        audioSource.PlayOneShot(menuSounds[1]);
        quitButton[0].SetActive(true);
        quitButton[1].SetActive(false);
    }

    /*
    public void SkipButton()
    {
        if (FinderMng.stageStates == Stage.Tutorial)
        {
            SceneManager.LoadScene("GameScene01");
        }else if(SceneManager.GetActiveScene().name == "GameScene01" || SceneManager.GetActiveScene().name == "GameScene02"|| SceneManager.GetActiveScene().name == "GameScene03")
        {
            SceneManager.LoadScene("SelectScene");
        }
        else
        {
            skip.SetActive(false);
        }
    }
    */
}
