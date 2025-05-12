using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class BathroomDialogue : MonoBehaviour
{
    public TextMeshProUGUI bathroomDialog;

    public string[] lines;
    public float textSpeed;
    private int tracker;

    void Start()
    {
        //clears dialogue before starting process
        bathroomDialog.text = string.Empty;
        gameObject.SetActive(false);
    }

    void OnTriggerEnter(Collider Player)
    {
        if (Player.gameObject.tag == "Player")
        {
            bathroomDialog.gameObject.SetActive(true);
            StartCoroutine(TypeLine());
        }
    }

    void Update()
    {
        //displays text when pressing mouse and skips if pressed
        if (Input.GetMouseButtonDown(0))
        {
            if (!gameObject.activeSelf) return;

            if (bathroomDialog.text == lines[tracker])
            {
                NextLine();
            }
            else
            {
                StopAllCoroutines();
                bathroomDialog.text = lines[tracker];
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
            bathroomDialog.text += c;
            yield return new WaitForSeconds(textSpeed);
        }
    }

    void NextLine()
    {
        //hides box if no text is detected
        if (tracker < lines.Length - 1)
        {
            tracker++;
            bathroomDialog.text = string.Empty;
            StartCoroutine(TypeLine());
        }
        else
        {
            bathroomDialog.gameObject.SetActive(false);
            Destroy(GetComponent<Collider>());
        }
    }
}
