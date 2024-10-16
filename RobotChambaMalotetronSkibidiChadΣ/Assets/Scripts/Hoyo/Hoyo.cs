using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class Hoyo : MonoBehaviour
{
    public GameObject door;
    public Animator animator;
    private GameObject Boton;
    void Start()
    {
        animator = GetComponent<Animator>();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if((collision.CompareTag("Amarillo") && this.CompareTag("Amarillo")) || 
            (collision.CompareTag("White") && this.CompareTag("White")) || 
            (collision.CompareTag("Blue") && this.CompareTag("Blue")))
        {
            Boton = collision.gameObject;

            //Dejar de hacer que sea movible
            Boton.GetComponent<Rigidbody2D>().isKinematic = false;
            Boton.transform.SetParent(null);
            //Boton = null;

            //Volverlo parte del fondo
            int defaultLayer = LayerMask.NameToLayer("Default");
            Boton.layer = defaultLayer;
            Boton.GetComponent<Rigidbody2D>().excludeLayers = 1 << defaultLayer;
            Boton.tag = "Ordenado";
            //Boton.GetComponent<Collider2D>().enabled = false;
            //Boton.GetComponent<BoxCollider2D>().enabled = false;
            //this.GetComponent<BoxCollider2D>().excludeLayers = 1 << defaultLayer;

            //Asignar nueva posicion
            Boton.transform.SetPositionAndRotation(this.GetComponent<Transform>().position, this.GetComponent<Transform>().rotation);

            this.GetComponent<BoxCollider2D>().enabled = false;

            if(this.CompareTag("Amarillo"))
            {
                //animator.SetBool("Open",true);
                door.GetComponent<Animator>().SetTrigger("Open");
                door.GetComponent<BoxCollider2D>().enabled=false; 
            }
        }
    }
}
