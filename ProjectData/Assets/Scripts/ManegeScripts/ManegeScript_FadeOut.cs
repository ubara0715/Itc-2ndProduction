using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ManegeScript_FadeOut : MonoBehaviour
{
    Image fadeImage;
    public SceneAsset nextScene;

    public float fadeoutSpeed;

    // Start is called before the first frame update
    void Start()
    {
        fadeImage = GetComponent<Image>();
    }

    void Awake()
    {
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator FadeOutScene()
    {
        fadeImage.enabled = true;
        Color sCI = fadeImage.color;
        Color eCI = new Color(sCI.r, sCI.b, sCI.g, 1.0f);
        float elapsedTime = 0.0f;

        while (elapsedTime < fadeoutSpeed)
        {
            elapsedTime += Time.deltaTime;
            float t = Mathf.Clamp01(elapsedTime / fadeoutSpeed);
            fadeImage.color = Color.Lerp(sCI, eCI, t);
            yield return null;
        }

        SceneManager.LoadScene(nextScene.name);
    }

    public void StartCor()
    {
        StartCoroutine(FadeOutScene());
    }
}
