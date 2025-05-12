using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnterHouseSequence : MonoBehaviour
{
    public PlayerMovement playerMove;
    public PlayerCamera playerCam;

    public InsideDialog dialogue;
    public Scream yelp;
    public AudioSource shatterSound;

    void Start()
    {
        // Disable movement during cutscene
        if (playerMove != null)
            playerMove.canMove = false;

        // Disable movement during cutscene
        if (playerCam != null)
            playerCam.canMove = false;

        if (dialogue != null)
        {
            dialogue.gameObject.SetActive(true);
            dialogue.StartDialogue();
        };


        // Trigger the animation sequence
        GetComponent<Animator>().SetTrigger("LookingSequence");
    }

    public void OnHouseAnimationEnd()
    {
        StartCoroutine(ReactionToSound());
    }

    IEnumerator ReactionToSound()
    {
        if (shatterSound != null)
            shatterSound.Play();

        yield return new WaitForSeconds(1f);

        if (yelp != null)
            yelp.StartDialogue();

        yield return new WaitForSeconds(1f);

        playerMove.canMove = true;
        playerCam.canMove = true;
    }

}
