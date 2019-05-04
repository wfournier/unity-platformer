using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PlayerController : MonoBehaviour
{

    private Rigidbody2D myRigidbody;
    private Animator myAnimator;

    private Vector2 currentVelocity;

    public float moveSpeed;
    public float jumpSpeed;

    public Transform groundCheck;
    public float groundCheckRadius;
    public LayerMask groundLayer;
    public bool isGrounded;

    public Vector3 respawnPosition;

    public LevelManager levelManager;

    // Start is called before the first frame update
    void Start()
    {
        myRigidbody = GetComponent<Rigidbody2D>();
        myAnimator = GetComponent<Animator>();
        respawnPosition = transform.position;
        levelManager = FindObjectOfType<LevelManager>();
    }

    // Update is called once per frame
    void Update()
    {
        currentVelocity = myRigidbody.velocity;
        isGrounded = Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, groundLayer);

        if (Input.GetAxisRaw("Horizontal") > 0f) // RIGHT
        {
            myRigidbody.velocity = new Vector2(moveSpeed, currentVelocity.y);
            transform.localScale = new Vector3(1f, 1f, 1f);
        }
        else if (Input.GetAxisRaw("Horizontal") < 0f) // LEFT
        {
            myRigidbody.velocity = new Vector2(-moveSpeed, currentVelocity.y);
            transform.localScale = new Vector3(-1f, 1f, 1f);
        }
        else // NEUTRAL
        {
            myRigidbody.velocity = new Vector2(0f, currentVelocity.y);
        }

        if (Input.GetButtonDown("Jump") && isGrounded) // JUMP
        {
            myRigidbody.velocity = Vector2.up * jumpSpeed;
        }

        myAnimator.SetFloat("Speed", Math.Abs(currentVelocity.x));
        myAnimator.SetBool("Grounded", isGrounded);
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("KillZone"))
        {
            levelManager.Respawn();
        }

        if (other.CompareTag("Checkpoint"))
        {
            respawnPosition = other.transform.position;
        }
    }

}