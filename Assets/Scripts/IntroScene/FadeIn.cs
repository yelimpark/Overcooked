using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FadeIn : MonoBehaviour
{
    private CanvasGroup canvas;
    public float fadeTime = 1f;
    float accumTime = 0f;

    private Coroutine fadeCoroutine;

    private void Awake()
    {
        canvas = gameObject.GetComponent<CanvasGroup>();
    }

    private void OnEnable()
    {
        StartFadeIn();
        
    }

    public void StartFadeIn()
    {
        if (fadeCoroutine != null)
        {
            StopAllCoroutines();
            fadeCoroutine = null;
        }
        fadeCoroutine = StartCoroutine(FadeInUI());
    }
    public void StartFadeOut()
    {
        if (fadeCoroutine != null)
        {
            StopAllCoroutines();
            fadeCoroutine = null;
        }
        fadeCoroutine = StartCoroutine(FadeOut());

    }

    private IEnumerator FadeInUI()
    {
        accumTime = 0f;
        while (accumTime < fadeTime)
        {
            canvas.alpha = Mathf.Lerp(0f, 1f, accumTime / fadeTime);
            yield return 0;
            accumTime += Time.deltaTime;
        }
        canvas.alpha = 1f;

        yield return new WaitForSeconds(1f);
        StartFadeOut();
    }


    private IEnumerator FadeOut()
    {
        accumTime = 0f;
        while (accumTime < fadeTime)
        {
            canvas.alpha = Mathf.Lerp(1f, 0f, accumTime / fadeTime);
            yield return 0;
            accumTime += Time.deltaTime;
        }
        canvas.alpha = 0f;
    }


}
