using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    #region Declarations --------------------------------------------------

    private PlayerController _player;

    private bool _moveLeftRequest;
    private bool _moveRightRequest;

    [Range(1, 10)] public float moveSpeed;

    #endregion


    #region Private/Protected Methods -------------------------------------

    private void Start()
    {
        _player = FindObjectOfType<PlayerController>();
    }

    private void Update()
    {
        if (Input.GetAxisRaw("Horizontal") < 0f) // LEFT
            _moveLeftRequest = true;
        else if (Input.GetAxisRaw("Horizontal") > 0f) // RIGHT
            _moveRightRequest = true;
    }

    private void FixedUpdate()
    {
        if (_moveLeftRequest)
        {
            _player.rigidBody.velocity = new Vector2(-moveSpeed, _player.rigidBody.velocity.y);
            transform.localScale = new Vector3(-1f, 1f, 1f);

            _moveLeftRequest = false;
        }
        else if (_moveRightRequest)
        {
            _player.rigidBody.velocity = new Vector2(moveSpeed, _player.rigidBody.velocity.y);
            transform.localScale = new Vector3(1f, 1f, 1f);

            _moveRightRequest = false;
        }
        else // NEUTRAL
        {
            _player.rigidBody.velocity = new Vector2(0f, _player.rigidBody.velocity.y);
        }
    }

    #endregion
}