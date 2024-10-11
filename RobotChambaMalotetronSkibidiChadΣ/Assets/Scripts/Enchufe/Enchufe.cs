using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Enchufe : MonoBehaviour
{
    private GameObject Conector;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Conector"))
        {
            Conector = collision.gameObject;

            //Dejar de hacer que sea movible
            Conector.GetComponent<Rigidbody2D>().isKinematic = false;
            Conector.transform.SetParent(null);
            //Conector = null;

            //Volverlo parte del fondo
            int defaultLayer = LayerMask.NameToLayer("Default");
            Conector.layer = defaultLayer;
            Conector.GetComponent<Rigidbody2D>().excludeLayers = 1 << defaultLayer;
            //Conector.GetComponent<Collider2D>().enabled = false;
            //Conector.GetComponent<BoxCollider2D>().enabled = false;
            //this.GetComponent<BoxCollider2D>().excludeLayers = 1 << defaultLayer;

            //Asignar nueva posicion
            Conector.transform.SetPositionAndRotation(this.GetComponent<Transform>().position, this.GetComponent<Transform>().rotation);
        }
    }
}
