using Mono.Cecil.Cil;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class DoorTrigger : MonoBehaviour
{
    public TextMeshProUGUI interactInstruction;
    public KnockInteraction knockInteract;

    private void Start()
    {
        interactInstruction.gameObject.SetActive(false);
        knockInteract.enabled = false;
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            interactInstruction.gameObject.SetActive(true);
            knockInteract.enabled = true;
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            interactInstruction.gameObject.SetActive(false);
            knockInteract.enabled = false;
        }
    }
}
