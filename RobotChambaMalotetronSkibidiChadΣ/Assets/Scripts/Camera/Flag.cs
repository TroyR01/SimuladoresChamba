using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flag : MonoBehaviour
{    
   
    public CameraMovement cameraMovementScript;  

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            cameraMovementScript.MoveCamera(true);  
            
            
        }
    }
}
