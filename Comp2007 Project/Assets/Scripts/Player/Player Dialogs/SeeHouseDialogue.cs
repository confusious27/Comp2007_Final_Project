using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class SeeHouseDialogue : MonoBehaviour
{

    public TextMeshProUGUI sawDialog;

    public string[] lines;
    public float textSpeed;
    private int tracker;

    void Start()
    {
        //clears dialogue before starting process
        sawDialog.text = string.Empty;
        gameObject.SetActive(false);
    }

    void Update()
    {
        //displays text when pressing mouse and skips if pressed
        if (Input.GetMouseButtonDown(0))
        {
            if (!gameObject.activeSelf) return;

            if (sawDialog.text == lines[tracker])
            {
                NextLine();
            }
            else
            {
                StopAllCoroutines();
                sawDialog.text = lines[tracker];
            }
        }
    }

    public void StartDialogue()
    {
        tracker = 0;
        gameObject.SetActive(true);
        StartCoroutine(TypeLine());
    }

    IEnumerator TypeLine()
    {
        //types each character 1 by 1
        foreach (char c in lines[tracker].ToCharArray())
        {
            sawDialog.text += c;
            yield return new WaitForSeconds(textSpeed);
        }
    }

    void NextLine()
    {
        //hides box if no text is detected
        if (tracker < lines.Length - 1)
        {
            tracker++;
            sawDialog.text = string.Empty;
            StartCoroutine(TypeLine());
        }
        else
        {
            gameObject.SetActive(false);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("OnTriggerEnter called"); // Debug message to check trigger activation
        if (other.CompareTag("Player")) // Ensure player has the "Player" tag
        {
            Debug.Log("Player detected"); // Debug message for player detection
            StartDialogue(); // Start the dialogue when the player enters the trigger
        }
        else
        {
            Debug.Log("Not the player"); // Debug message to check if another object triggers the collider
        }
       
    }
}
