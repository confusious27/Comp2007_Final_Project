using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class BedroomDialogue : MonoBehaviour
{
    public TextMeshProUGUI bedroomDialog;

    public string[] lines;
    public float textSpeed;
    private int tracker;

    void Start()
    {
        //clears dialogue before starting process
        bedroomDialog.text = string.Empty;
        gameObject.SetActive(false);
    }

    void OnTriggerEnter(Collider Player)
    {
        if (Player.gameObject.tag == "Player")
        {
            bedroomDialog.gameObject.SetActive(true);
            StartCoroutine(TypeLine());
        }
    }

    void Update()
    {
        //displays text when pressing mouse and skips if pressed
        if (Input.GetMouseButtonDown(0))
        {
            if (!gameObject.activeSelf) return;

            if (bedroomDialog.text == lines[tracker])
            {
                NextLine();
            }
            else
            {
                StopAllCoroutines();
                bedroomDialog.text = lines[tracker];
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
            bedroomDialog.text += c;
            yield return new WaitForSeconds(textSpeed);
        }
    }

    void NextLine()
    {
        //hides box if no text is detected
        if (tracker < lines.Length - 1)
        {
            tracker++;
            bedroomDialog.text = string.Empty;
            StartCoroutine(TypeLine());
        }
        else
        {
            bedroomDialog.gameObject.SetActive(false);
            Destroy(GetComponent<Collider>());
        }
    }
}
