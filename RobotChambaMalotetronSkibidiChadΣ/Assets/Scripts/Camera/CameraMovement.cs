using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    public Transform player;          // Referencia al jugador
    public float moveSpeed = 2f;      // Velocidad de movimiento de la cámara
    public GameObject door;           // Referencia a la puerta u otro objeto que se activa
    private bool cameraCanMove = false; 
    private bool followPlayerY = false;  // Nueva variable para seguir al jugador en Y

    private float initialX;           // Posición inicial en el eje X de la cámara
    private float initialZ;           // Posición inicial en el eje Z de la cámara

    [Header("Target X Position")]
    public float targetXPosition;     // Coordenada objetivo en el eje X hacia donde la cámara se moverá

    void Start()
    {
        // Guardamos la posición inicial de la cámara en los ejes X y Z
        initialX = transform.position.x;
        initialZ = transform.position.z;
    }

    void Update()
    {
        // Solo mover la cámara si cameraCanMove es true (es decir, cuando la bandera lo permita)
        if (cameraCanMove)
        {
            // Movimiento en el eje X: La cámara se moverá hacia `targetXPosition`
            Vector3 targetPositionX = new Vector3(targetXPosition, transform.position.y, transform.position.z);
            transform.position = Vector3.Lerp(transform.position, targetPositionX, moveSpeed * Time.deltaTime);

            // Si la cámara está cerca del objetivo en el eje X, se detiene y sigue al jugador en el eje Y
            if (Mathf.Abs(transform.position.x - targetXPosition) < 0.1f)
            {
                cameraCanMove = false;         // Detenemos el movimiento en X
                followPlayerY = true;          // Habilitamos el seguimiento en Y
                door.SetActive(true);          // Activamos la puerta u otro evento
            }
        }

        // Si la bandera `followPlayerY` es verdadera, la cámara sigue al jugador en el eje Y
        if (followPlayerY)
        {
            Vector3 targetPositionY = new Vector3(transform.position.x, player.position.y, transform.position.z);
            transform.position = Vector3.Lerp(transform.position, targetPositionY, moveSpeed * Time.deltaTime);
        }
    }

    // Función que activa el movimiento de la cámara desde otro script (por ejemplo, la bandera)
    public void MoveCamera(bool canMove)
    {
        cameraCanMove = canMove;  
    }
}
