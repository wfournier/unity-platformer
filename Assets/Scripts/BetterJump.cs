using UnityEngine;

public class BetterJump : MonoBehaviour
{
    #region Declarations --------------------------------------------------

    public float fallMultiplier = 2.5f;
    public float lowJumpMultiplier = 2f;

    private Rigidbody2D _rb;

    #endregion


    #region Private/Protected Methods -------------------------------------

    private void Awake()
    {
        _rb = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
    {
        if (_rb.velocity.y < 0)
            _rb.gravityScale = fallMultiplier;
        else if (_rb.velocity.y > 0 && !Input.GetButton("Jump"))
            _rb.gravityScale = lowJumpMultiplier;
        else
            _rb.gravityScale = 1f;
    }

    #endregion
}