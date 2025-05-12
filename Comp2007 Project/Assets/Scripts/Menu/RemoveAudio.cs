using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RemoveAudio : MonoBehaviour
{
    //GameObjects with this will be destroyed in 3 secs
    public void Start()
    {
        Destroy(gameObject, 3f);
    }
}
