using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public abstract class Interactable : MonoBehaviour
{
    //message displayed to player when looking at interactable
    public TextMeshProUGUI promptMessage;
   
    //function will be called from player
    public void baseInteract()
    {
        Interact();
    }

    protected virtual void Interact()
    {
        //no code as this is a template function to override with subclasses
    }
}
