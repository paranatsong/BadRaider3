﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed;
    public float jumpForce;
    private bool camMove;
    private Rigidbody2D theRB2D;

    public bool grounded;
    public LayerMask whatIsGrd;
    public Transform grdChecker;
    public float grdCheckerRad;

    public float airTime;
    public float airTimeCounter;

    private Animator theAnimator;

    
    void Start()
    {
        theRB2D = GetComponent<Rigidbody2D>();
        theAnimator = GetComponent<Animator>();

        airTimeCounter = airTime;
    }

    
    void Update()
    {
        if(Input.GetAxisRaw("Horizontal") > 0.5f || Input.GetAxisRaw("Horizontal") < -0.5)
        {
            camMove = true;
        }
    }

    private void FixedUpdate()
    {
        grounded = Physics2D.OverlapCircle(grdChecker.position, grdCheckerRad, whatIsGrd);

        MovePlayer();
        Jump();
    }

    void MovePlayer()
    {
        if (camMove)
        {
            theRB2D.velocity = new Vector2(Input.GetAxisRaw("Horizontal") * speed, theRB2D.velocity.y);

            theAnimator.SetFloat("Speed", Mathf.Abs(theRB2D.velocity.x));

            if (theRB2D.velocity.x > 0)
                transform.localScale = new Vector2(0.2627542f, 0.2627542f);
            else if (theRB2D.velocity.x < 0)
                transform.localScale = new Vector2(-0.2627542f, 0.2627542f);
        }
    }

    void Jump()
    {
        if (grounded == true)
        {
            if (Input.GetKeyDown(KeyCode.Space) || Input.GetMouseButtonDown(0))
            {
                theRB2D.velocity = new Vector2(theRB2D.velocity.x, jumpForce);
            }
        }

        if(Input.GetKey(KeyCode.Space) || Input.GetMouseButton(0))
        {
            if(airTimeCounter > 0)
            {
                theRB2D.velocity = new Vector2(theRB2D.velocity.x, jumpForce);
                airTimeCounter -= Time.deltaTime;
            }
        }

        if(Input.GetKeyUp(KeyCode.Space) || Input.GetMouseButtonUp(0))
        {
            airTimeCounter = 0;
        }

        if (grounded)
        {
            airTimeCounter = airTime;
        }

        theAnimator.SetBool("Grounded", grounded);
    }

}
