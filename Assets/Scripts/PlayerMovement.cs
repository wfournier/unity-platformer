﻿using UnityEngine;


public class PlayerMovement : MonoBehaviour
{

    #region Declarations --------------------------------------------------

    private PlayerController player;

    private bool moveLeftRequest;
    private bool moveRightRequest;

    [Range(1, 10)]
    public float moveSpeed;

    #endregion


    #region Private/Protected Methods -------------------------------------

    private void Start()
    {
        player = FindObjectOfType<PlayerController>();
    }

    private void Update()
    {
        if (Input.GetAxisRaw("Horizontal") < 0f) // LEFT
        {
            moveLeftRequest = true;
        }
        else if (Input.GetAxisRaw("Horizontal") > 0f) // RIGHT
        {
            moveRightRequest = true;
        }
    }

    private void FixedUpdate()
    {
        if (moveLeftRequest)
        {
            player.rigidBody.velocity = new Vector2(-moveSpeed, player.rigidBody.velocity.y);
            transform.localScale = new Vector3(-1f, 1f, 1f);

            moveLeftRequest = false;
        }
        else if (moveRightRequest)
        {
            player.rigidBody.velocity = new Vector2(moveSpeed, player.rigidBody.velocity.y);
            transform.localScale = new Vector3(1f, 1f, 1f);

            moveRightRequest = false;
        }
        else // NEUTRAL
        {
            player.rigidBody.velocity = new Vector2(0f, player.rigidBody.velocity.y);
        }
    }

    #endregion

}