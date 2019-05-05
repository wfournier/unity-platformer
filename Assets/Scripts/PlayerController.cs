using System;
using UnityEngine;


public class PlayerController : MonoBehaviour
{

    #region Declarations --------------------------------------------------

    [HideInInspector]
    public Rigidbody2D rigidBody;
    [HideInInspector]
    public Animator animator;
    [HideInInspector]
    public Vector2 size;
    [HideInInspector]
    public Vector2 feetContactBox;

    private Vector2 currentVelocity;

    public float groundedSkin = 0.05f;
    public LayerMask groundLayer;
    public LayerMask killZoneLayer;
    public bool grounded;
    public bool isInKillZone;

    public Vector3 respawnPosition;

    public LevelManager levelManager;

    #endregion


    #region Private/Protected Methods -------------------------------------

    private void Awake()
    {
        feetContactBox = new Vector2(size.x, groundedSkin);
    }

    // Start is called before the first frame update
    private void Start()
    {
        rigidBody = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        size = GetComponent<BoxCollider2D>().size;
        respawnPosition = transform.position;
        levelManager = FindObjectOfType<LevelManager>();
    }

    // Update is called once per frame
    private void Update()
    {
        animator.SetFloat("SpeedX", Math.Abs(rigidBody.velocity.x));
    }

    private void FixedUpdate()
    {
        Vector2 boxCenter = (Vector2) transform.position + (size.y + feetContactBox.y) * 0.5f * Vector2.down;

        grounded = Physics2D.OverlapBox(boxCenter, feetContactBox, 0f, groundLayer);
        isInKillZone = Physics2D.OverlapBox(boxCenter, feetContactBox, 0f, killZoneLayer);
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