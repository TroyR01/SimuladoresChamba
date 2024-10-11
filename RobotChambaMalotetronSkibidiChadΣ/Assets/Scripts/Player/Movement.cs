using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
   private Rigidbody2D rb2d;
   // public RailCamera railCamera; // Referencia al script de la cámara


    [Header("Horizontal Movement")]
    private float movementX = 0;
    [SerializeField] private float movementVelocity;
    [Range(0, 0.3f)][SerializeField] private float smoothMovement;
    private Vector3 velocity = Vector3.zero;
    private bool lookRight = true;
    private Vector2 input;


    [Header("Jump")]
    [SerializeField] private float jumpForce;
    [SerializeField] private LayerMask whatIsFloor;
    [SerializeField] private Transform floorController;
    [SerializeField] private Vector3 sizeBoxFloorController;
    [SerializeField] private bool isGrounded;

    // Variables para la altura máxima
    private float maxJumpHeight = 0f;
    private float landingY = 0f;


   


    [Header("Particle")]
    [SerializeField] private ParticleSystem footsteps;
    private ParticleSystem.EmissionModule footEmmision;
    [SerializeField] private ParticleSystem impactEffect;
    [SerializeField] private bool wasOnGround;

    [Header("Animator")]
    [SerializeField] private Animator animator;

   

 
   /* [Header("MenuManager")]
    [SerializeField] private MenuManagerLevel menuManager;*/

    // Start is called before the first frame update
    void Start()
    {
        //Se obtienen los componentes basicos a utilizar
        rb2d = GetComponent<Rigidbody2D>();
        
        // animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        /*if (menuManager.isPaused)
            return;*/

        

        //Movimiento del jugador
        input.y = Input.GetAxisRaw("Vertical");
        movementX = Input.GetAxisRaw("Horizontal") * movementVelocity;
        Move(movementX * Time.fixedDeltaTime);


        //Deteccion para saber si el jugador esta tocando o no el suelo
        isGrounded = Physics2D.OverlapBox(floorController.position, sizeBoxFloorController, 0f, whatIsFloor);

       

        //Debug.Log(input.y);

        if (input.y < 0)
        {
            // DisablePlatforms();
            Collider2D[] objects = Physics2D.OverlapBoxAll(floorController.position, sizeBoxFloorController, 0f, whatIsFloor);
            foreach (Collider2D item in objects)
            {
                PlatformEffector2D platformEffector2D = item.GetComponent<PlatformEffector2D>();
                if (platformEffector2D != null)
                {
                    Physics2D.IgnoreCollision(GetComponent<Collider2D>(), item.GetComponent<Collider2D>(), true);
                }
            }
        }
        //Salto del jugador
        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            rb2d.velocity = new Vector2(rb2d.velocity.x, jumpForce);
            maxJumpHeight = transform.position.y; // Iniciar con la altura actual al saltar
        }
        if (!isGrounded && rb2d.velocity.y > 0)
        {
            maxJumpHeight = Mathf.Max(maxJumpHeight, transform.position.y);

        }

        //Salto dependiendo de cuanto presionemos el boton de salto
        if (Input.GetButtonUp("Jump") && rb2d.velocity.y > 0)
        {
            rb2d.velocity = new Vector2(rb2d.velocity.x, rb2d.velocity.y * 0.5f);
            // rb2d.AddForce(new Vector2(0f, jumpForce));
        }

 


        //Emision de particulas, si se esta tocando el suelo y se esta moviendo, emitira particulas
        /*if (movementX != 0 && isGrounded)
        {
            footEmmision.rateOverTime = 20f;
        }
        else
        {
            footEmmision.rateOverTime = 0;
        }*/

        //Emision de particulas a saltar, Si el frame anterior no se estaba en el suelo y posteriormente si, emitira particulas de polvo
        if (!wasOnGround && isGrounded)
        {
            landingY = transform.position.y; // Guardar la posición Y de aterrizaje

            // Calcular la diferencia de altura
            float heightDifference = maxJumpHeight - landingY;

            // Calcular la magnitud del temblor basado en la diferencia de altura, con un máximo de 0.1
            float shakeMagnitude = Mathf.Min(heightDifference * 0.005f, 0.1f);

            // Temblor de la cámara al aterrizar
           // railCamera.TriggerShake(shakeMagnitude, 0.1f);

            /*impactEffect.gameObject.SetActive(true);
            impactEffect.Stop();
            impactEffect.transform.position = footsteps.transform.position;
            impactEffect.Play();*/
        }
        wasOnGround = isGrounded;


        //Variables de animacion
        Debug.Log(movementX);
        animator.SetFloat("movementX", Mathf.Abs(movementX));
        animator.SetBool("onFloor", isGrounded);

        // animator.SetFloat("inputY", rb2d.velocity.y);

    }


    private void FixedUpdate()
    {
        movementX = Input.GetAxisRaw("Horizontal") * movementVelocity;

        
       

        //animator.SetFloat("VelocityY", rb2d.velocity.y);
        animator.SetFloat("movementX", Mathf.Abs(Input.GetAxisRaw("Horizontal")));
        
    }

   

   

  

   
    private void Move(float movement)
    {
     
        Vector3 finalVelocity = new Vector2(movement, rb2d.velocity.y);
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


    private void OnDrawGizmos()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireCube(floorController.position, sizeBoxFloorController);

        Gizmos.color = Color.blue;
    }
}
