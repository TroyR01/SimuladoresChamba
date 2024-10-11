using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float life = 10f;  // Tiempo de vida en segundos

    void Start()
    {
        Destroy(gameObject, life);  // Destruye la bala después de "life" segundos
    }
    
    void OnCollisionEnter2D(Collision2D collision)
    {
        
        Destroy(gameObject);
    }
}
