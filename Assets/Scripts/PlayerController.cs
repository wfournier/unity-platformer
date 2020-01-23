using System;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    #region Declarations --------------------------------------------------

    private Vector2 _currentVelocity;
    private Vector2 _feetContactBox;

    [HideInInspector] public Rigidbody2D rigidBody;

    [HideInInspector] public Animator animator;

    [HideInInspector] public Vector2 size;

    [HideInInspector] public LevelManager levelManager;

    public float groundedSkin = 0.05f;
    public LayerMask groundLayer;
    public LayerMask killZoneLayer;
    public bool isGrounded;
    public bool isInKillZone;
    public bool invulnerable;
    public bool dead;

    [Range(0.1f, 10f)] public float invulnerabilityWindow;

    public Vector3 respawnPosition;

    #endregion


    #region Private/Protected Methods -------------------------------------

    private void Awake()
    {
        rigidBody = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        size = GetComponent<BoxCollider2D>().size;
        respawnPosition = transform.position;
        levelManager = FindObjectOfType<LevelManager>();
        _feetContactBox = new Vector2(size.x, groundedSkin);
    }

    private void Update()
    {
        animator.SetFloat("SpeedX", Math.Abs(rigidBody.velocity.x));
    }

    private void FixedUpdate()
    {
        var boxCenter = (Vector2) transform.position + (size.y + _feetContactBox.y) * 0.5f * Vector2.down;

        isGrounded = Physics2D.OverlapBox(boxCenter, _feetContactBox, 0f, groundLayer);
        isInKillZone = Physics2D.OverlapBox(boxCenter, _feetContactBox, 0f, killZoneLayer);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("KillZone")) levelManager.RespawnPlayer();

        if (other.CompareTag("Checkpoint")) respawnPosition = other.transform.position;
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("MovingPlatform")) transform.parent = other.transform;
    }

    private void OnCollisionExit2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("MovingPlatform")) transform.parent = null;
    }

    public void Kill()
    {
        gameObject.SetActive(false);
        dead = true;
    }

    public void Respawn()
    {
        gameObject.SetActive(true);
        dead = false;
    }

    #endregion
}