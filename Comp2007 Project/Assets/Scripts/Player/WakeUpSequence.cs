using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class WakeUpSequence : MonoBehaviour
{
    public GameObject eyelids;
    public PlayerMovement playerMove;
    public PlayerCamera playerCam;

    public WakeUpDialogue dialogue;

    void Start()
    {
        // Disable movement during cutscene
        if (playerMove != null)
            playerMove.canMove = false;

        // Disable movement during cutscene
        if (playerCam != null)
            playerCam.canMove = false;

        dialogue.gameObject.SetActive(false);


        // Trigger the animation sequence
        GetComponent<Animator>().SetTrigger("StartingSequence");

    }

    public void OnCompleteBlink()
    {
        if (eyelids != null)
            Destroy(eyelids);
    }

    public void OnWakeUpAnimationEnd()
    {

        //re-enable movement
        playerMove.canMove = true;

        //re-enable cam movement
        playerCam.canMove = true;

        dialogue.gameObject.SetActive(true);
        dialogue.StartDialogue();
    }

}