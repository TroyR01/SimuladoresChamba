using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    private Rigidbody2D rb2d;

    [Header("Horizontal Movement")]
    private float movementX = 0;
    [SerializeField] private float movementVelocity;
    [Range(0, 0.3f)][SerializeField] private float smoothMovement;
    private Vector3 velocity = Vector3.zero;
    private bool lookRight = true;
    private Vector2 input;

    [Header("Jump")]
    [SerializeField] private float jumpForce;
    private bool isGrounded = false; // Para saber si está tocando el suelo

    [Header("Particle")]
    [SerializeField] private ParticleSystem footsteps;
    private ParticleSystem.EmissionModule footEmmision;
    [SerializeField] private ParticleSystem impactEffect;
    [SerializeField] private bool wasOnGround;

    [Header("Animator")]
    [SerializeField] private Animator animator;

    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
    }

    void Update()
    {

        input.y = Input.GetAxisRaw("Vertical");
        movementX = Input.GetAxisRaw("Horizontal") * movementVelocity;
        Move(movementX * Time.fixedDeltaTime);

        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            rb2d.velocity = new Vector2(rb2d.velocity.x, jumpForce);
        }

        if (Input.GetButtonUp("Jump") && rb2d.velocity.y > 0)
        {
            rb2d.velocity = new Vector2(rb2d.velocity.x, rb2d.velocity.y * 0.5f);
        }

        if (!wasOnGround && isGrounded)
        {
        }

        wasOnGround = isGrounded;

        animator.SetFloat("movementX", Mathf.Abs(movementX));
    }

    private void FixedUpdate()
    {
        movementX = Input.GetAxisRaw("Horizontal") * movementVelocity;
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

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Floor"))
        {
            isGrounded = true; 
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Floor"))
        {
            isGrounded = false; 
        }
    }
}
