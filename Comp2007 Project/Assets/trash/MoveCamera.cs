using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveCamera : MonoBehaviour
{
    public Transform cameraPosition;

    //make camera move with player
    private void Update()
    {
        transform.position = cameraPosition.position;
    }
}
