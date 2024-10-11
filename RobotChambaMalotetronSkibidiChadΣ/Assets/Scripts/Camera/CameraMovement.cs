using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    public Vector3 targetPosition;  
    public float moveSpeed = 2f;    
     public GameObject door;
    private bool cameraCanMove = false;  

    void Update()
    {
        if (cameraCanMove)
        {
            transform.position = Vector3.Lerp(transform.position, targetPosition, moveSpeed * Time.deltaTime);
             
            if (Vector3.Distance(transform.position, targetPosition) < 0.1f)
            {
                cameraCanMove = false;
                door.SetActive(true);
            }
              
        }
    }

    public void moveCamera(bool canMove)
    {
        cameraCanMove = canMove;  
    }
}
