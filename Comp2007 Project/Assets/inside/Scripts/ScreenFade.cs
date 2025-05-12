using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScreenFade : MonoBehaviour
{
    public Image fadeImage;
    public float fadeDuration = 1f;

    private void Awake()
    {
        if (fadeImage != null)
        {
            fadeImage.canvasRenderer.SetAlpha(0);
        }
    }

    public IEnumerator FadeToBlack()
    {
        fadeImage.CrossFadeAlpha(1, fadeDuration, false);
        yield return new WaitForSeconds(fadeDuration);
    }
}
