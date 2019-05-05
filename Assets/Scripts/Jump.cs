using UnityEngine;


public class Jump : MonoBehaviour
{

    #region Declarations --------------------------------------------------

    private PlayerController player;
    private bool jumpRequest;
    private Vector2 boxSize;

    [Range(1, 10)]
    public float jumpVelocity;
    public float groundedSkin = 0.05f;
    public LayerMask groundMask;

    #endregion


    #region Private/Protected Methods -------------------------------------

    private void Awake()
    {
        player = FindObjectOfType<PlayerController>();
        boxSize = new Vector2(player.size.x, groundedSkin);
    }

    private void Update()
    {
        player.animator.SetBool("Grounded", player.isGrounded);

        if (Input.GetButtonDown("Jump") && player.isGrounded)
        {
            jumpRequest = true;
        }
    }

    private void FixedUpdate()
    {
        if (jumpRequest)
        {
            player.rigidBody.AddForce(Vector2.up * jumpVelocity, ForceMode2D.Impulse);

            jumpRequest = false;
            player.isGrounded = false;
        }
        else
        {
            Vector2 boxCenter = (Vector2) transform.position + (player.size.y + boxSize.y) * 0.5f * Vector2.down;
            player.isGrounded = Physics2D.OverlapBox(boxCenter, boxSize, 0f, groundMask);
        }
    }

    #endregion

}