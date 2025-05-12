//using System.Collections;
//using System.Collections.Generic;
//using TMPro;
//using UnityEngine;

//public class BlockStairs : MonoBehaviour
//{ 
//    public GameObject key;
//    public GameObject player;
//    public TextMeshProUGUI stairsDialog;

//    public string[] dialogueLines;
//    public float textSpeed;
//    private int dialogueIndex = 0;

//    private bool hasKey = false;
//    private bool isInDialogue = true;

//    private Collider blockCollider;

//    void Start()
//    {
//        blockCollider = GetComponent<Collider>();
//        blockCollider.isTrigger = true;
//        blockCollider.enabled = true;
//        ShowDialogue();
//    }

//    void Update()
//    {
//        //check if player pick up key
//        if (!hasKey && isInDialogue)
//        {
//            BlockPlayerMovement();
//        }

//        //block player if no key
//        if (!hasKey)
//        {
//            BlockPlayerMovement();
//        }

//        if (isInDialogue && Input.GetMouseButtonDown(0))
//        {
//            if (stairsDialog.text == dialogueLines[dialogueIndex])
//            {
//                NextLine();
//            }
//            else
//            {
//                StopAllCoroutines();
//                stairsDialog.text = dialogueLines[dialogueIndex];
//            }
//        }
//    }

//    void BlockPlayerMovement()
//    {
//        if (blockCollider != null && player.GetComponent<Collider>().bounds.Intersects(blockCollider.bounds))
//        {
//            player.GetComponent<Rigidbody>().velocity = Vector3.zero;
//        }

//        void OnTriggerEnter(Collider other)
//        {
//            // When the player enters the collider, trigger the dialogue
//            if (other.CompareTag("Player") && !hasKey)
//            {
//                isInDialogue = true;
//                ShowDialogue();
//            }
//        }

//        void OnTriggerExit(Collider other)
//        {
//            // Once the player leaves the collider area, stop the dialogue
//            if (other.CompareTag("Player") && !hasKey)
//            {
//                isInDialogue = false;
//                stairsDialog.gameObject.SetActive(false); // Hide dialogue UI
//            }
//        }

//    }

//    void ShowDialogue()
//    {
//        // Display the dialogue UI
//        stairsDialog.gameObject.SetActive(true);
//        StartCoroutine(TypeLine());
//    }

//    IEnumerator TypeLine()
//    {
//        foreach (char c in dialogueLines[dialogueIndex].ToCharArray())
//        {
//            stairsDialog.text += c;
//            yield return new WaitForSeconds(textSpeed);
//        }
//    }

//    void PickupKey()
//    {
//        hasKey = true;
//        key.SetActive(false);

//        stairsDialog.gameObject.SetActive(false);
//        AllowPlayerMovement();
//    }

//    void BlockPlayerMovement()
//    {
//        player.GetComponent<PlayerMovement>().enabled = false; // Assuming there’s a script controlling movement
//    }

//    void AllowPlayerMovement()
//    {
//        // Enable player movement after they pick up the key
//        player.GetComponent<PlayerMovement>().enabled = true;
//    }
//}
//}
