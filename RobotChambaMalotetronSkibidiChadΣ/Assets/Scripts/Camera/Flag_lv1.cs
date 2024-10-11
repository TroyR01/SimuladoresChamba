using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flag_lv1 : MonoBehaviour
{    
   
    public CameraMovement cameraMovementScript;  
    public GameObject canva;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            canva.SetActive(false); 
            cameraMovementScript.MoveCamera(true);  
            
            
        }
    }
}
