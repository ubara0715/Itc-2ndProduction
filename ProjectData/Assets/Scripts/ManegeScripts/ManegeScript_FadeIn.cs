using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ManegeScript_FadeIn : MonoBehaviour
{
    public float fadeinSpeed;
    public static bool IsFadeIn;

    Image fadeImage;

    // Start is called before the first frame update
    void Start()
    {
        IsFadeIn = false;
        fadeImage = GetComponent<Image>();

        StartCoroutine(FadeinScene());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator FadeinScene()
    {
        fadeImage.enabled = true;
        float elapsedTime = 0.0f;
        Color sCI = fadeImage.color;
        Color eCI = new Color(sCI.r, sCI.b, sCI.g, 0.0f);
        
        while (elapsedTime < fadeinSpeed)
        {
            elapsedTime += Time.deltaTime;
            float t = Mathf.Clamp01(elapsedTime / fadeinSpeed);
            fadeImage.color = Color.Lerp(sCI, eCI, t);
            yield return null;
        }

        fadeImage.color = eCI;
        IsFadeIn = true;
        gameObject.SetActive(false);
    }
}
