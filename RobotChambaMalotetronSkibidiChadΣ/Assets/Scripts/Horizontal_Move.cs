using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps; 
using UnityEngine.SceneManagement;

public class Horizontal_Move : MonoBehaviour
{
     public TransitionManager transitionManager;
    [SerializeField] private Tilemap tilemap;  // Referencia al Tilemap
    [SerializeField] private Tile oldTile;
    [SerializeField] private Tile newTile;  // El nuevo tile con el estilo que quieres
    public Vector3Int[] coordinates;
    public int counter = 0;
    private Rigidbody2D rb2d;
   // public RailCamera railCamera; // Referencia al script de la cámara

    public Shake_Camera mainCamera;
    public Animator animator;
    [Header("Horizontal Movement")]
    private float movementX = 0;
    [SerializeField] private float movementVelocity;
    [Range(0, 0.3f)][SerializeField] private float smoothMovement;
    private Vector3 velocity = Vector3.zero;
    private bool lookRight = true;
    private Vector2 input;
    private AudioSource audioSource;
    // Start is called before the first frame update
    void Start()
    {
         rb2d = GetComponent<Rigidbody2D>();
         audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        movementX = Input.GetAxisRaw("Horizontal") * movementVelocity;
        Move(movementX * Time.fixedDeltaTime);
    }
    private void FixedUpdate()
    {
        movementX = Input.GetAxisRaw("Horizontal") * movementVelocity;
        
    }
    void OnCollisionEnter2D(Collision2D other)
    {
        // Esto se ejecuta cuando el objeto entra en un trigger
        Debug.Log("Entró en trigger con: " + other.gameObject.name);

        if (other.gameObject.CompareTag("Good")&&counter<20)
        {
            Debug.Log("Entró en trigger con una energia");
            tilemap.SetTile(coordinates[counter],newTile);
            counter++;
            // Aquí puedes manejar lo que ocurre al interactuar con un enemigo
        }
        if (other.gameObject.CompareTag("Bad"))
        {
            animator.SetTrigger("Damage");
            mainCamera.TriggerShake(0.2f, 0.2f);
            if(counter>0)
            {
                audioSource.Play();
                Debug.Log("Entró en trigger con un ruido");
                tilemap.SetTile(coordinates[counter-1],oldTile);
                counter--;
            }
            // Aquí puedes manejar lo que ocurre al interactuar con un enemigo
        }
        if(counter == 5)
        {
            
            transitionManager.Transition("Menu");
            
        }
    }
    private void Move(float movement)
    {
     
        Vector3 finalVelocity = new Vector2(movement, 0);
        rb2d.velocity = Vector3.SmoothDamp(rb2d.velocity, finalVelocity, ref velocity, smoothMovement);

        if (movement > 0 && !lookRight)
        {
            Turn();
        }
        else if (movement < 0 && lookRight)
        {
            Turn();
        }
    }
    private void Turn()
    {
        lookRight = !lookRight;
        Vector3 scale = transform.localScale;
        scale.x *= -1;
        transform.localScale = scale;
    }
}
