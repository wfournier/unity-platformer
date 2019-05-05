using UnityEngine;


public class Jump : MonoBehaviour
{

    #region Declarations --------------------------------------------------

    private PlayerController player;
    private bool jumpRequest;

    [Range(1, 10)]
    public float jumpVelocity;

    #endregion


    #region Private/Protected Methods -------------------------------------

    private void Start()
    {
        player = FindObjectOfType<PlayerController>();
    }

    private void Update()
    {
        player.isGrounded = Physics2D.OverlapCircle(player.groundCheck.position, player.groundCheckRadius, player.groundLayer);
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
        }
    }

    #endregion

}