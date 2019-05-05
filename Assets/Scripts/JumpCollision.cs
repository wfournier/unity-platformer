using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class JumpCollision : MonoBehaviour
{

    #region Declarations --------------------------------------------------

    private PlayerController player;
    private bool jumpRequest;
    private List<Collider2D> groundTouched;

    [Range(1, 10)]
    public float jumpVelocity;

    #endregion


    #region Private/Protected Methods -------------------------------------

    private void Start()
    {
        player = FindObjectOfType<PlayerController>();
        groundTouched = new List<Collider2D>();
    }

    private void Update()
    {
        player.isGrounded = groundTouched.Any();
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

    void OnCollisionEnter2D(Collision2D other)
    {
        var points = new ContactPoint2D[2];
        other.GetContacts(points);

        if (points.Any(point => point.normal == Vector2.up) && !groundTouched.Contains(other.collider))
        {
            groundTouched.Add(other.collider);
        }
    }

    private void OnCollisionExit2D(Collision2D other)
    {
        if (groundTouched.Contains(other.collider))
        {
            groundTouched.Remove(other.collider);
        }
    }

    #endregion

}
