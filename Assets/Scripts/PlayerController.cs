using System;
using UnityEngine;


public class PlayerController : MonoBehaviour
{

    #region Declarations --------------------------------------------------

    [HideInInspector]
    public Rigidbody2D rigidBody;
    [HideInInspector]
    public Animator animator;

    private Vector2 currentVelocity;
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
        rigidBody = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        respawnPosition = transform.position;
        levelManager = FindObjectOfType<LevelManager>();
    }

    // Update is called once per frame
    private void Update()
    {
        isInKillZone = Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, killZoneLayer);

        animator.SetFloat("SpeedX", Math.Abs(rigidBody.velocity.x));
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