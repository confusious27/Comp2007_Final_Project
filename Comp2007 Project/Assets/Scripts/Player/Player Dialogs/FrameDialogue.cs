using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class FrameDialogue : MonoBehaviour
{
    public TextMeshProUGUI frameDialog;

    public string[] lines;
    public float textSpeed;
    private int tracker;

    void Start()
    {
        //clears dialogue before starting process
        frameDialog.text = string.Empty;
        gameObject.SetActive(false);
    }

    void Update()
    {
        //displays text when pressing mouse and skips if pressed
        if (Input.GetMouseButtonDown(0))
        {
            if (!gameObject.activeSelf) return;

            if (frameDialog.text == lines[tracker])
            {
                NextLine();
            }
            else
            {
                StopAllCoroutines();
                frameDialog.text = lines[tracker];
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
            frameDialog.text += c;
            yield return new WaitForSeconds(textSpeed);
        }
    }

    void NextLine()
    {
        //hides box if no text is detected
        if (tracker < lines.Length - 1)
        {
            tracker++;
            frameDialog.text = string.Empty;
            StartCoroutine(TypeLine());
        }
        else
        {
            gameObject.SetActive(false);
        }
    }
}
