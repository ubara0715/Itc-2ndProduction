using UnityEditor.Media;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class SceneScript_Tutorial : MonoBehaviour
{
    enum Tutorial_Main
    {
        Start,
        PlayGuido,
        DemoPlay,
        SceneChange
    }

    public string[] sentence01, sentence02, sentence03;
    public GameObject cat;
    public GameObject catMouse;
    public GameObject[] Mode;
    public Text sentenceText;
    public AudioClip[] tutorialSounds;
    public AudioClip sutterSoundT;
    int index;

    Tutorial_Main tutorial;
    ManegeScript_Object objectMng;
    Animator animator;
    AudioSource audioSource;

    // Start is called before the first frame update
    void Start()
    {
        sentenceText = sentenceText.GetComponent<Text>();
        objectMng = cat.GetComponent<ManegeScript_Object>();
        animator = catMouse.GetComponent<Animator>();
        audioSource = GetComponent<AudioSource>();
    }

    void Awake()
    {
        Mode[0].SetActive(false);
        Mode[1].SetActive(false);
        Mode[2].SetActive(false);

        tutorial = Tutorial_Main.Start;
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0) && tutorial == Tutorial_Main.DemoPlay)
        {
            audioSource.PlayOneShot(sutterSoundT);
        }

        switch (tutorial)
        {
            case Tutorial_Main.Start:
                Cursor.visible = true;
                StartState();
                if (!(index <= sentence01.Length - 1))
                {
                    PlayGuidoState();
                    index = 0;
                }
                break;
            case Tutorial_Main.PlayGuido:
                PlayGuidoState();
                if (!(index <= sentence02.Length - 1))
                {
                    DemoPlayState();
                    index = 0;
                }
                break;
            case Tutorial_Main.DemoPlay:
                Cursor.visible = false;
                DemoPlayState();
                if (objectMng.getted == true) SceneChangeState();
                break;
            case Tutorial_Main.SceneChange:
                Cursor.visible = true;
                SceneChangeState();
                if (!(index <= sentence03.Length - 1))
                {
                    index = 0;
                }
                break;
        }
    }

    // Update is called once per frame
    void LateUpdate()
    {
        if (animator.GetBool("IsTalk") == true)
        {
            Invoke("BoolReset", 0.1f);
        }
    }

    public void IsNext()
    {
        index++;
        animator.SetBool("IsTalk", true);
        audioSource.PlayOneShot(tutorialSounds[0]);
    }

    public void IsBack()
    {
        if(index >= 1)
        {
            index--;
            animator.SetBool("IsTalk", true);
            audioSource.PlayOneShot(tutorialSounds[1]);
        }
    }

    void StartState()
    {
        tutorial = Tutorial_Main.Start;

            Mode[0].SetActive(true);
            Mode[1].SetActive(false);
            Mode[2].SetActive(false);

        if (index <= sentence01.Length - 1)
        {
            sentenceText.text = sentence01[index];
        }
    }

    void PlayGuidoState()
    {
        tutorial = Tutorial_Main.PlayGuido;

        Mode[0].SetActive(true);
        Mode[1].SetActive(false);
        Mode[2].SetActive(false);

        if (index <= sentence02.Length - 1)
        {
            sentenceText.text = sentence02[index];
        }
    }

    void DemoPlayState()
    {
        tutorial = Tutorial_Main.DemoPlay;

        Mode[0].SetActive(false);
        Mode[1].SetActive(true);
        Mode[2].SetActive(true);
    }

    void SceneChangeState()
    {
        tutorial = Tutorial_Main.SceneChange;

        Mode[0].SetActive(true);
        Mode[1].SetActive(true);
        Mode[2].SetActive(false);

        if (index <= sentence03.Length - 1)
        {
            sentenceText.text = sentence03[index];
        }

        if (!(index <= sentence03.Length - 2))
        {
            GameObject.Find("FadeOutCanvas").GetComponent<ManegeScript_FadeOut>().SendMessage("StartCor");
        }

        return;
    }

    void BoolReset()
    {
        animator.SetBool("IsTalk", false);
    }
}
