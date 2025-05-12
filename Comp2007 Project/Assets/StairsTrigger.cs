//using System.Collections;
//using System.Collections.Generic;
//using TMPro;
//using UnityEngine;

//public class StairsTrigger : MonoBehaviour
//{
//    public TextMeshProUGUI doorBlockDialog;
//    public BlockStairs blockStairs;

//    void OnTriggerEnter(Collider other)
//    {
//        if (other.CompareTag("Player") && !blockStairs.HasKey)
//        {
//            blockStairs.StartDialogue();
//        }
//    }

//    void OnTriggerExit(Collider other)
//    {
//        // Once the player leaves the collider area, stop the dialogue
//        if (other.CompareTag("Player") && !blockStairs.HasKey)
//        {
//            blockStairs.StopDialogue();
//        }
//    }
//}
