using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class WakeUpDialogue : MonoBehaviour
{

    public TextMeshProUGUI wakeupDialog;
    public TextMeshProUGUI moveInstruction;

    public string[] lines;
    public float textSpeed;
    private int tracker;

    void Awake()
    {
        //clears dialogue before starting process
        wakeupDialog.text = string.Empty;
        moveInstruction.gameObject.SetActive(false);
        gameObject.SetActive(false);
    }

    void Update()
    {
        //displays text when pressing mouse and skips if pressed
        if (Input.GetMouseButtonDown(0))
        {
            if (!gameObject.activeSelf) return;

            if (wakeupDialog.text == lines[tracker])
            {
                NextLine();
            }
            else
            {
                StopAllCoroutines();
                wakeupDialog.text = lines[tracker];
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
            wakeupDialog.text += c;
            yield return new WaitForSeconds(textSpeed);
        }

    }

    void NextLine()
    {
        //hides box if no text is detected
        if (tracker < lines.Length - 1)
        {
            tracker++;
            wakeupDialog.text = string.Empty;
            StartCoroutine(TypeLine());
        }
        else
        {
            wakeupDialog.text = string.Empty;
            StartCoroutine(ShowInstructions());
        }
    }

    IEnumerator ShowInstructions()
    {

        moveInstruction.gameObject.SetActive(true);
        yield return new WaitForSeconds(3f);
        moveInstruction.gameObject.SetActive(false);
   
        gameObject.SetActive(false);
    }

}