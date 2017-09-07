﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControllerScripts : MonoBehaviour
{
    public float fireRate = 0;
    public float damage = 1;
    public LayerMask NotToHit;
    public GameObject bullet;
    public Vector2 offset = new Vector2(0.4f, 0.4f);

    bool grounded = false;
    public Transform groundCheck;
    public float groundRadius = 0.5f;
    public LayerMask whatIsGround;

    public float maxSpeed = 10f;
    public float jumpForce = 450f;
    public bool facingRight = true;
    public Rigidbody2D Body;
    Animator anim;
    Rigidbody2D myRigidbody;

    // Use this for initialization
    void Start()
    {
        anim = GetComponent<Animator>();
        Body = GetComponent<Rigidbody2D>();
        myRigidbody = GetComponent<Rigidbody2D>();
    }

    // Updated once every frame
    private void Update()
    {
        CheckForJump();

        float move = Input.GetAxis("Horizontal");
        Body.velocity = new Vector2(move * maxSpeed, Body.velocity.y);

        anim.SetFloat("Speed", Mathf.Abs(move));
        if (move > 0 && !facingRight)
        {
            Flip();
        }
        else if (move < 0 && facingRight)
        {
            Flip();
        }

        if (fireRate == 0)
        {
            CheckForShot();

        }
    }

    private void CheckForJump()
    {
        if (grounded && (Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(KeyCode.UpArrow)))
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

    void Flip()
    {
        facingRight = !facingRight;
        SpriteRenderer flipX = GetComponent<SpriteRenderer>();
        flipX.flipX = !facingRight;
    }

    public void Tester()
    {
        anim.SetTrigger("TEST");
    }

    private void CheckForShot()
    {
        if (true) // Check to make sure there are maximum 3 shots in the air at any given time
        {
            if (Input.GetKeyDown(KeyCode.X))
            {
                if (anim.GetCurrentAnimatorStateInfo(0).IsName("Player_Idle"))
                {
                    Debug.Log("IDLE Shoot");
                    //Instantiate(bullet, (Vector2)transform.position + offset * transform.localScale.x, Quaternion.identity);
                    anim.SetTrigger("Idle_Shoot");
                }
                else if (anim.GetCurrentAnimatorStateInfo(0).IsName("Player_Jump&Fall"))
                {
                    anim.SetTrigger("Jumping_Shoot");
                    anim.Play("Player_Shoot_In_Air");
                    Debug.Log("JUMPING Shoot");
                }
                else if (anim.GetCurrentAnimatorStateInfo(0).IsName("Player_Run"))
                {
                    Debug.Log("RUNNING Shoot");
                    anim.SetTrigger("Run_Shoot");
                }
            }
        }
    }


    //private void OnCollisionEnter2D(Collision2D collision)
    //{
    //    if (collision.gameObject.tag == "Ground")
    //    {
    //        JumpCount = MaxJumps;
    //    }
    //}

    void Jump()
    {
        myRigidbody.AddForce(new Vector2(0, jumpForce));
        //anim.SetTrigger("Jump");
        //JumpCount -= 1;
    }
}
