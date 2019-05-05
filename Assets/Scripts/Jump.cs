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

    private void Awake()
    {
        player = FindObjectOfType<PlayerController>();
    }

    private void Update()
    {
        player.animator.SetBool("Grounded", player.grounded);

        if (Input.GetButtonDown("Jump") && player.grounded)
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
            player.grounded = false;
        }
    }

    #endregion

}