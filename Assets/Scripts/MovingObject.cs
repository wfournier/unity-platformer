﻿using UnityEngine;


public class MovingObject : MonoBehaviour
{

    #region Declarations --------------------------------------------------

    private Animator objectAnimator;

    public GameObject objectToMove;
    public Transform startPoint;
    public Transform endPoint;
    public float moveSpeed;

    public Vector3 currentTarget;

    #endregion


    #region Private/Protected Methods -------------------------------------

    // Start is called before the first frame update
    private void Start()
    {
        objectAnimator = objectToMove.GetComponent<Animator>();
        currentTarget = endPoint.position;
    }

    // Update is called once per frame
    private void Update()
    {
        objectToMove.transform.position = Vector3.MoveTowards(objectToMove.transform.position, currentTarget, moveSpeed * Time.deltaTime);

        if (objectToMove.transform.position == endPoint.position)
        {
            currentTarget = startPoint.position;
            objectAnimator.SetBool("Clockwise", false);
        }
        else if (objectToMove.transform.position == startPoint.position)
        {
            currentTarget = endPoint.position;
            objectAnimator.SetBool("Clockwise", true);
        }
    }

    #endregion

}