using UnityEngine;


public class BetterJump : MonoBehaviour
{

    #region Declarations --------------------------------------------------

    public float fallMultiplier = 2.5f;
    public float lowJumpMultiplier = 2f;

    private Rigidbody2D rb;

    #endregion


    #region Private/Protected Methods -------------------------------------

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        if (rb.velocity.y < 0)
        {
            rb.velocity += Physics2D.gravity.y * (fallMultiplier - 1) * Time.deltaTime * Vector2.up;
        }
        else if (rb.velocity.y > 0 && !Input.GetButton("Jump"))
        {
            rb.velocity += Physics2D.gravity.y * (lowJumpMultiplier - 1) * Time.deltaTime * Vector2.up;
        }
    }

    #endregion

}