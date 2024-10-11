using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraProvisional : MonoBehaviour
{
    public Vector3 targetPosition;  // La posición a la que quieres mover la cámara
    public float moveSpeed = 2f;    // Velocidad del movimiento de la cámara

    private bool cameraCanMove = false;  // Para saber si la cámara debe moverse

    void Update()
    {
        if (cameraCanMove)
        {
            // Movemos la cámara suavemente hacia la nueva posición
            transform.position = Vector3.Lerp(transform.position, targetPosition, moveSpeed * Time.deltaTime);

            // Si la cámara ya ha llegado a la posición destino, detenemos el movimiento
            if (Vector3.Distance(transform.position, targetPosition) < 0.1f)
            {
                cameraCanMove = false;
            }
        }
    }

    public void moveCamera(bool canMove)
    {
        cameraCanMove = canMove;  // Activamos o desactivamos el movimiento de la cámara
    }
}