using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEditor.Rendering;
using UnityEngine;
using UnityEngine.SceneManagement;

public class KnockInteraction : MonoBehaviour
{
    public TextMeshProUGUI knockDialog;
    public GameObject Instruction;
    public GameObject dialogPanel;

    public string[] lines;
    public float textSpeed;
    private int tracker = 0;

    public AudioClip knockSound;
    private AudioSource audioSource;

    private bool hasInteract = false;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        if (audioSource == null)
        {
            audioSource = gameObject.AddComponent<AudioSource>();
        }
    }

    void Update()
    {
        if (!hasInteract && Input.GetKeyDown(KeyCode.Space) && Instruction.activeSelf)
        {
            Instruction.SetActive(false);
            dialogPanel.SetActive(true);
            hasInteract = true;

            if (knockSound != null)
                audioSource.PlayOneShot(knockSound);

                StartCoroutine(TypeLines());  

        }

    }

    IEnumerator TypeLines()
    {
        // Loop through all lines
        for (int i = 0; i < lines.Length; i++)
        {
            knockDialog.text = "";

            foreach (char c in lines[i])
            {
                knockDialog.text += c;
                yield return new WaitForSeconds(textSpeed);
            }

            yield return new WaitForSeconds(1f);
        }

        StartCoroutine(LoadSceneAfterDialogue());
    }

    IEnumerator LoadSceneAfterDialogue()
    {
        Debug.Log("Loading scene...");
        yield return new WaitForSeconds(1f);

        GameObject currentPlayer = GameObject.FindGameObjectWithTag("Player");
        CharacterController characterController = currentPlayer.GetComponent<CharacterController>();

        if (characterController != null)
        {
            characterController.enabled = false;  // Disable the CharacterController
            currentPlayer.SetActive(false); // Optionally deactivate the player object
        }

        SceneManager.LoadScene(2);
        yield return null;
    }

}