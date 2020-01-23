using UnityEngine;


public class PlayerJump : MonoBehaviour
{

    #region Declarations --------------------------------------------------

    private PlayerController player;
    private bool jumpRequest;

    [Range(1, 10)]
    public float jumpVelocity;

    #endregion


    #region Private/Protected Methods -------------------------------------

    private void Awake()
    {
        player = FindObjectOfType<PlayerController>();
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
    }

    #endregion

}