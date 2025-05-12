//using System.Collections;
//using System.Collections.Generic;
//using TMPro;
//using UnityEngine;
//using UnityEngine.SceneManagement;

//public class KnockInteraction : MonoBehaviour
//{
//    public TextMeshProUGUI knockdialog;
//    public GameObject Instruction;
//    public AudioClip knockSound;
//    public string nextScene = "InsideHouse";

//    private bool canInteract = false;
//    private bool hasKnocked = false;

//    private bool playerRange = false;

//    private void OnTriggerEnter(Collider other)
//    {
//        if (other.CompareTag("Player"))
//        {
//            playerRange = true;
//            showInteractionPrompt.SetActive(true);
//        }
//    }

//    private void OnTriggerExit(Collider other)
//    {
//        if (other.CompareTag("Player"))
//        {
//            playerRange = false;
//            showInteractionPrompt.SetActive(false);
//        }
//    }

//    void Update()
//    {
//        if (playerRange && Input.GetKeyDown(KeyCode.Space))
//        {
//            showInteractionPrompt.SetActive(false);
//            KnockDoor();
//        }
//    }

//    private void ShowPrompt(bool show)
//    {
//        ShowInteractionPrompt
//    }

//    private void KnockDoor()
//    {
//        if (knockSound != null)
//        {
//            AudioSource.PlayClipAtPoint(knockSound, transform.position);
//        }

//        if (dialogueManager != null)
//        {
//            dialogueManager.lines = new string[] { "Huh? The door is open!" };
//            dialogueManager.StartDialogue();

//        }

//        StartCoroutine(SceneLoad());
//    }

//    IEnumerator SceneLoad()
//    {
//        yield return new WaitForSeconds(fadeDelay);

//        SceneFader fader = FindObjectOfType<SceneFader>();
//        if (fader != null)
//        {
//            fader.FadeToScene(inside);
//        }
//        else
//        {
//            SceneManager.LoadScene(inside);
//        }

//    }
//}
