using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class JumpscareTrigger : MonoBehaviour
{
    public AudioSource jumpscareSound;
    public AudioSource collapseSound;

    public GameObject rat;

    public ScreenFade screenFader;
    private RatControl ratControl;


    private bool triggered = false;

    private void Start()
    {
        if (rat != null)
        {
            ratControl = rat.GetComponent<RatControl>();
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (triggered) return;

        if (other.CompareTag("Player"))
        {
            rat.SetActive(true);
            triggered = true;
            StartCoroutine(PlayJumpscareSequence());
        }
    }

    IEnumerator PlayJumpscareSequence()
    {
        if (jumpscareSound != null)
            jumpscareSound.Play();

        if (ratControl != null)
        {
            ratControl.StartMoving(new Vector3(-25.9338551f, -11.2700005f, -89.7684784f));
        }

        float totalDistance = Vector3.Distance(rat.transform.position, ratControl.targetPosition);
        float halfWayDistance = totalDistance / 2f;

        while (Vector3.Distance(rat.transform.position, ratControl.targetPosition) > halfWayDistance)
        {
            yield return null;
        }

        if (screenFader != null)
            yield return StartCoroutine(screenFader.FadeToBlack());

        yield return new WaitForSeconds(1F);

        if (collapseSound != null)
            collapseSound.Play();

        yield return new WaitForSeconds(1f);
        SceneManager.LoadScene(0);
    }
}
