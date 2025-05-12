using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEditor.Rendering;
using UnityEngine;

public class InsideDialog : MonoBehaviour
{
    public TextMeshProUGUI insideDialog;

    public string[] lines;
    public float textSpeed;
    private int tracker;

    public bool dialogueActive = false;

    void Awake()
    {
        //clears dialogue before starting process
        insideDialog.text = string.Empty;
        gameObject.SetActive(false);
    }

    void Update()
    {
        if (!dialogueActive) return;

        //displays text when pressing mouse and skips if pressed
        if (Input.GetMouseButtonDown(0))
        {
            if (!gameObject.activeSelf) return;

            if (insideDialog.text == lines[tracker])
            {
                NextLine();
            }
            else
            {
                StopAllCoroutines();
                insideDialog.text = lines[tracker];
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
            insideDialog.text += c;
            yield return new WaitForSeconds(textSpeed);
        }

    }

    void NextLine()
    {
        //hides box if no text is detected
        if (tracker < lines.Length - 1)
        {
            tracker++;
            insideDialog.text = string.Empty;
            StartCoroutine(TypeLine());
        }
        else
        {
            EndDialogue();
        }
    }

    void EndDialogue()
    {
        insideDialog.text = string.Empty;
        dialogueActive = false;
    }
}