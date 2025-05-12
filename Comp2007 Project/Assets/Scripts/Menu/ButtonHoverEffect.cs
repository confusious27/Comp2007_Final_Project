using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System.Collections;
using Unity.VisualScripting;

public class ButtonHoverEffect : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler, IPointerDownHandler, IPointerUpHandler
{
    private CanvasGroup canvasGroup; //reference to canvasgroup to control the alpha of color
    private Image buttonImage;

    public Color normalColor = Color.blue;
    public float pulseSpeed = 0.3f; //speed for the pulsing effect
    public float minAlpha = 0.5f; //the transparency value
    public float maxAlpha = 1f; //the opposite of transparency value

    private bool isPulsing = false; //for pulse effect
    

    private void Start()
    {
        canvasGroup = GetComponent<CanvasGroup>();
        buttonImage = GetComponent<Image>();

        //to make sure the button starts with the normal color
        buttonImage.color = normalColor;

        //checks the canvasgroup component to make sure the button is fully visible
        if (canvasGroup != null)
        {
            canvasGroup.alpha = 1f;
        }
        
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        StartPulsing();
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        StopPulsing();
        //ensures the color returns to normal and is fully visible
        buttonImage.color = normalColor;
        if (canvasGroup != null)
        {
            canvasGroup.alpha = 1f;
        }
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        buttonImage.color = normalColor;
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        buttonImage.color = normalColor;
    }

    //to start the pulsing effect
    private void StartPulsing()
    {
        if (!isPulsing)
        {
            isPulsing = true;
            StartCoroutine(PulseEffect());
        }
    }

    //to stop the pulsing effect
    private void StopPulsing()
    {
        isPulsing = false;
        StopCoroutine(PulseEffect());
    }


    private IEnumerator PulseEffect()
    {
        float lerpTime = 0f;

        while (isPulsing)
        {
            //use of independent timer for each button
            lerpTime += Time.unscaledDeltaTime * pulseSpeed;

            //this allows for the alpha to go back and forth smoothly
            float alpha = Mathf.PingPong(lerpTime, maxAlpha - minAlpha) + minAlpha;
            buttonImage.color = new Color(normalColor.r, normalColor.g, normalColor.b, alpha);
            yield return null;
        }
    }
}
