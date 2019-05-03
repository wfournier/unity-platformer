using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody2D myRigidbody;
    private Animator myAnimator;

    public float moveSpeed;
    public float jumpSpeed;

    private Vector2 currentVelocity;

    public Transform groundCheck;
    public float groundCheckRadius;
    public LayerMask whatIsGround;

    public bool isGrounded;

    // Start is called before the first frame update
    void Start()
    {
        myRigidbody = GetComponent<Rigidbody2D>();
        myAnimator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        currentVelocity = myRigidbody.velocity;
        isGrounded = Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, whatIsGround);

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

        if (Input.GetButton("Jump") && isGrounded) // JUMP
        {
            myRigidbody.velocity = new Vector2(currentVelocity.x, jumpSpeed);
        }

        myAnimator.SetFloat("Speed", Math.Abs(currentVelocity.x));
        myAnimator.SetBool("Grounded", isGrounded);
    }
}
