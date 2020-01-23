using UnityEngine;

public class PlayerJump : MonoBehaviour
{
    #region Declarations --------------------------------------------------

    private PlayerController _player;
    private bool _jumpRequest;

    [Range(1, 10)] public float jumpVelocity;

    #endregion


    #region Private/Protected Methods -------------------------------------

    private void Awake()
    {
        _player = FindObjectOfType<PlayerController>();
    }

    private void Update()
    {
        _player.animator.SetBool("Grounded", _player.isGrounded);

        if (Input.GetButtonDown("Jump") && _player.isGrounded) _jumpRequest = true;
    }

    private void FixedUpdate()
    {
        if (_jumpRequest)
        {
            _player.rigidBody.AddForce(Vector2.up * jumpVelocity, ForceMode2D.Impulse);

            _jumpRequest = false;
            _player.isGrounded = false;
        }
    }

    #endregion
}