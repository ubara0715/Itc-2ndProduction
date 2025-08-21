using UnityEngine;
using UnityEngine.SceneManagement;

public class ManegeScript_StartButton : MonoBehaviour
{
    public AudioClip startSound;
    public AudioClip selectSound;
    AudioSource audioSource;

    public GameObject[] ExitButtons;

    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void IsStart()
    {
        audioSource.PlayOneShot(startSound);
        audioSource.volume = 0.8f;
        GameObject.Find("FadeOutCanvas").GetComponent<ManegeScript_FadeOut>().SendMessage("StartCor");
    }

    public void IsExit()
    {
        audioSource.PlayOneShot(selectSound);
        ExitButtons[0].SetActive(false);
        ExitButtons[1].SetActive(true);
    }

    public void IsExitTure()
    {
        UnityEditor.EditorApplication.isPlaying = false;
        Application.Quit();
    }

    public void IsExitFalse()
    {
        audioSource.PlayOneShot(selectSound);
        ExitButtons[0].SetActive(true);
        ExitButtons[1].SetActive(false);
    }
}
