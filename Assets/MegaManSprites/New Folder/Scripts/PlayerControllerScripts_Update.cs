using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControllerScripts_Update : MonoBehaviour
{
    bool grounded = false;
    public Transform groundCheck;
    public float groundRadius = 0.5f;
    public LayerMask whatIsGround;

    public float jumpForce = 450f;
    Animator anim;
    Rigidbody2D myRigidbody;

    // Use this for initialization
    void Start()
    {
        anim = GetComponent<Animator>();
        myRigidbody = GetComponent<Rigidbody2D>();
    }

    // Updated once every frame
    private void Update()
    {
        CheckForJump();
    }

    private void CheckForJump()
    {
        if (grounded && (Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(KeyCode.Keypad8) || Input.GetKeyDown(KeyCode.UpArrow)))
        {
            Jump();
        }
    }

    // Update is called at the same time as the physics engine
    void FixedUpdate()
    {
        grounded = Physics2D.OverlapCircle(groundCheck.position, groundRadius, whatIsGround);
        anim.SetBool("Ground", grounded);
    }

    public void Tester()
    {
        anim.SetTrigger("TEST");
    }

    void Jump()
    {
        myRigidbody.AddForce(new Vector2(0, jumpForce));
    }
}
