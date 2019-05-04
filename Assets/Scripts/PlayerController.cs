using System;
using UnityEngine;


public class PlayerController : MonoBehaviour
{

    #region Declarations --------------------------------------------------

    private Rigidbody2D myRigidbody;
    private Animator myAnimator;

    private Vector2 currentVelocity;

    public float moveSpeed;
    public float jumpSpeed;

    public Transform groundCheck;
    public float groundCheckRadius;
    public LayerMask groundLayer;
    public LayerMask killZoneLayer;
    public bool isGrounded;
    public bool isInKillZone;

    public Vector3 respawnPosition;

    public LevelManager levelManager;

    #endregion


    #region Private/Protected Methods -------------------------------------

    // Start is called before the first frame update
    private void Start()
    {
        myRigidbody = GetComponent<Rigidbody2D>();
        myAnimator = GetComponent<Animator>();
        respawnPosition = transform.position;
        levelManager = FindObjectOfType<LevelManager>();
    }

    // Update is called once per frame
    private void Update()
    {
        currentVelocity = myRigidbody.velocity;
        isGrounded = Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, groundLayer);
        isInKillZone = Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, killZoneLayer);

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

    private void OnTriggerEnter2D(Collider2D other)
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

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("MovingPlatform"))
        {
            transform.parent = other.transform;
        }
    }

    private void OnCollisionExit2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("MovingPlatform"))
        {
            transform.parent = null;
        }
    }

    #endregion

}