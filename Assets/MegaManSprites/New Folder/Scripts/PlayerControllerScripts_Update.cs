using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControllerScripts_Update : MonoBehaviour
{
    bool grounded = false;
    public Transform groundCheck;
    public float groundRadius = 0.4f;
    public LayerMask whatIsGround;

    public float jumpForce = 1;
    Animator anim;
    Rigidbody2D myRigidbody;

    // Ladder Stuff:
    public bool onLadder;
    public float climbSpeed;
    private float climbVelocity;
    private float gravityStore;

    // Use this for initialization
    void Start()
    {
        anim = GetComponent<Animator>();
        myRigidbody = GetComponent<Rigidbody2D>();
        gravityStore = myRigidbody.gravityScale;
    }

    // Updated once every frame
    private void Update()
    {
        CheckForJump();

        if (onLadder)
        {
            myRigidbody.gravityScale = 0f;

            //if (Input.GetKeyDown(KeyCode.UpArrow))
            //{
                climbVelocity = climbSpeed * Input.GetAxisRaw("Vertical");

                myRigidbody.velocity = new Vector2(myRigidbody.velocity.x, climbVelocity);
            //}
        }
        if (!onLadder)
        {
            myRigidbody.gravityScale = gravityStore;
        }
    }

    private void CheckForJump()
    {
        if (grounded && (Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(KeyCode.Keypad8)))
        {
            Jump();
        }
    }

    // Update is called at the same time as the physics engine
    void FixedUpdate()
    {
        grounded = Physics2D.OverlapCircle(groundCheck.position, groundRadius, whatIsGround);
        //grounded = Physics2D.OverlapArea(transform.position, transform.position, whatIsGround);
        anim.SetBool("Ground", grounded);

    }

    public void Tester()
    {
        anim.SetTrigger("TEST");
    }

    void Jump()
    {
        myRigidbody.AddForce(new Vector2(0, jumpForce));
        //myRigidbody.velocity = Vector2.up * jumpForce;
    }
}
