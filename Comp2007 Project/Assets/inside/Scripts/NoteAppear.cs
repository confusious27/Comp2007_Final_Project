using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class NoteAppear : MonoBehaviour, IInteractable
{
    public GameObject BlackScreen;
    public TextMeshProUGUI interaction;
    public TextMeshProUGUI finalThought;
    public TextMeshProUGUI finalThought2;
    private bool canInteract = false;

    [SerializeField]
    private Image noteImage;

    private void Start()
    {
        BlackScreen.SetActive(false);
        noteImage.gameObject.SetActive(false);
        interaction.gameObject.SetActive(false);
    }

    //triggers image to pop up onscreen
    private void OnTriggerEnter(Collider Player)
    {
        if (Player.gameObject.tag == "Player")
        {
            Debug.Log("ENTERED TRIGGER ZONE");
            interaction.gameObject.SetActive(true);
            canInteract = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            interaction.gameObject.SetActive(false);
            canInteract = false;
        }
    }

    void Update()
    {
        if (canInteract && Input.GetKeyDown(KeyCode.Space))
        {
            Debug.Log("Interacted with note");
            Interact();
        }
    }

    public void Interact()
    {
        if (canInteract)
        {
            StartCoroutine(FinalSequence());
        }
    }

    IEnumerator FinalSequence()
    {
        yield return new WaitForSeconds(2f);
        interaction.gameObject.SetActive(false);

        noteImage.gameObject.SetActive(true);
        yield return new WaitForSeconds(1f);
        noteImage.gameObject.SetActive(false);

        BlackScreen.SetActive(true);
        BlackScreen.GetComponent<Animator>().SetTrigger("Fading");

        finalThought.gameObject.SetActive(true);
        yield return new WaitForSeconds(5f);
        finalThought.gameObject.SetActive(false);

        finalThought2.gameObject.SetActive(true);
        yield return new WaitForSeconds(5f);
        finalThought2.gameObject.SetActive(false);

        //Loads main menu
        SceneManager.LoadScene(0);
    }
}
