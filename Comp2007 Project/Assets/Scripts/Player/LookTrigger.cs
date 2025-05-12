using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookTrigger : MonoBehaviour
{
    public SeeHouseDialogue dialogSee;
    public float triggerDistance = 500f;
    private bool hasTrigger = false;

    void Update()
    {
        Debug.DrawRay(transform.position, transform.forward * triggerDistance, Color.red);

        if (hasTrigger) return;

        Ray rays = new Ray(transform.position, transform.forward);
        RaycastHit hit;

        if (Physics.Raycast(rays, out hit, triggerDistance))
        {
            if (hit.collider.CompareTag("House"))
            {
                Debug.Log("Player is looking at the house.");
                dialogSee.StartDialogue();
                hasTrigger = true;
            }
        }
    }
}
