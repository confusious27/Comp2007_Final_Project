using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;

public class DialogueManager : MonoBehaviour
{

    public TextMeshProUGUI textComponent;
    public GameObject dialoguePanel;
    
    public string[] lines;
    public float textSpeed;

    private int tracker;

    void Start()
    {
        //clears dialogue before starting process
        textComponent.text = string.Empty;
        StartDialogue();
    }

    void Update()
    {
        //displays text when pressing mouse and skips if pressed
        if (dialoguePanel.activeSelf && Input.GetMouseButtonDown(0))
        {
            if (textComponent.text == lines[tracker])
            {
                NextLine();
            }
            else
            {
                StopAllCoroutines();
                textComponent.text = lines[tracker];
            }
        }
    }

    public void SetLines(string[] newLines)
    {
        lines = newLines;
    }

    public void StartDialogue()
    {
        if (lines == null || lines.Length == 0)
        {
            Debug.LogWarning("No lines set for dialogue.");
            return;
        }

        tracker = 0;
        dialoguePanel.SetActive(true);
        StartCoroutine(TypeLine());
    }

    IEnumerator TypeLine()
    {
        textComponent.text = "";
        //types each character 1 by 1
        foreach (char c in lines[tracker].ToCharArray())
        {
            textComponent.text += c;
            yield return new WaitForSeconds(textSpeed);
        }
    }

    void NextLine()
    {
        //hides box if no text is detected
        if (tracker < lines.Length - 1)
        {
            tracker++;
            textComponent.text = string.Empty;
            StartCoroutine(TypeLine());
        }
        else
        {
            dialoguePanel.SetActive(false);
        }
    }
}
