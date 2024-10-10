using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Button : MonoBehaviour
{
    public GameObject door;

    // Asegúrate de que el objeto del botón tiene un Collider2D con la opción "Is Trigger" marcada

    
    private void OnTriggerEnter2D(Collider2D collision)
    {
        
        if(collision.CompareTag("Player"))
        {
            door.SetActive(false); 
           
        }
    }
    

    /*private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            door.SetActive(true); // Abre la puerta
            Debug.Log("Puerta abierta");
        }
    }*/
}
