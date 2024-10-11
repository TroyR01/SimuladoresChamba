using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    public Transform player;          // Referencia al jugador
    public float moveSpeed = 2f;      // Velocidad de movimiento de la cámara
    public GameObject door;           // Referencia a la puerta u otro objeto que se activa
    private bool cameraCanMove = false; 

    private float initialX;           // Posición inicial en el eje X de la cámara
    private float initialZ;           // Posición inicial en el eje Z de la cámara

    void Start()
    {
        // Guardamos la posición inicial de la cámara en los ejes X y Z
        initialX = transform.position.x;
        initialZ = transform.position.z;
    }

    void Update()
    {
        // La cámara sigue al jugador en el eje Y de manera libre
        Vector3 targetPosition = new Vector3(transform.position.x, player.position.y, transform.position.z);
        transform.position = Vector3.Lerp(transform.position, targetPosition, moveSpeed * Time.deltaTime);

        // Si se puede mover en X, entonces se ajusta la posición en ese eje
        if (cameraCanMove)
        {
            Vector3 targetPositionX = new Vector3(initialX, player.position.y, initialZ);
            transform.position = Vector3.Lerp(transform.position, targetPositionX, moveSpeed * Time.deltaTime);
            
            // Si la cámara está cerca del objetivo, dejamos de moverla en X
            if (Vector3.Distance(transform.position, targetPositionX) < 0.1f)
            {
                cameraCanMove = false;
                door.SetActive(true);  // Activa la puerta u otro evento
            }
        }
    }

    public void moveCamera(bool canMove)
    {
        cameraCanMove = canMove;  
    }
}
