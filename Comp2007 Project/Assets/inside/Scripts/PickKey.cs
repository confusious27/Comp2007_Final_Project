using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickKey : MonoBehaviour
{
    public GameObject Instruction;
    public GameObject ThisTrigger;
    public GameObject KeyOnGround;
    public GameObject KeyInHand;
    public bool PickUp = false;

    void Start()
    {
        ThisTrigger.SetActive(true);
        KeyOnGround.SetActive(true);
        KeyInHand.SetActive(false);
    }

    void OnTriggerEnter(Collider collision)
    {
        if (collision.transform.tag == "Player")
        {
            Instruction.SetActive(true);
            PickUp = true;
        }
    }

    private void OnTriggerExit(Collider collision)
    {
        Instruction.SetActive(false );
        PickUp = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        { 
            if (PickUp == true)
            {
                Instruction.SetActive(false);
                KeyOnGround.SetActive(false);
                KeyInHand.SetActive(true);
                ThisTrigger.SetActive(false);
                PickUp = false;
            }
        }
    }
}
