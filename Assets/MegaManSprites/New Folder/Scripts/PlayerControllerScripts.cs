using System;
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

    public float maxSpeed = 10f;
    public float jumpForce = 450f;
    public bool facingRight = true;
    public Rigidbody2D Body;
    Animator anim;
    Rigidbody2D myRigidbody;
    int JumpCount = 0;
    public int MaxJumps = 1; //Maximum amount of jumps (i.e. 2 for double jumps)

    // Use this for initialization
    void Start()
    {
        JumpCount = MaxJumps;
        anim = GetComponent<Animator>();
        Body = GetComponent<Rigidbody2D>();
        myRigidbody = GetComponent<Rigidbody2D>();
    }
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


    // Update is called at the same time as the physics engine
    void FixedUpdate()
    {

        // Make sure that the character is facing the way he's moving

        //If the character is falling, animate the falling sprites
        if (myRigidbody.velocity.y < 0)
        {
            anim.SetBool("HasLanded", false);
            anim.SetTrigger("Falling");
        }
        else
        {
            anim.ResetTrigger("Falling");
        }


    }

    void Flip()
    {
        facingRight = !facingRight;
        SpriteRenderer flipX = GetComponent<SpriteRenderer>();
        flipX.flipX = !facingRight;
    }

    void CheckForJump()
    {
        if (JumpCount > 0)
        {
            if (Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(KeyCode.UpArrow))
            {
                anim.SetBool("HasLanded", false);
                Jump();
            }
        }
    }

    private void CheckForShot()
    {
        if (true) // Check to make sure there are maximum 3 shots in the air at any given time
        {
            if (Input.GetKeyDown(KeyCode.X))
            {
                // FIRE EVERYTHING!!!
                Debug.Log("FIRE EVERYTHING!!!");
                //Instantiate(bullet, (Vector2)transform.position + offset * transform.localScale.x, Quaternion.identity);
                anim.SetTrigger("Idle_Shoot");
            }
        }
    }


    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Ground")
        {
            anim.SetBool("HasLanded", true);
            anim.ResetTrigger("Falling");
            anim.ResetTrigger("Jump");
            JumpCount = MaxJumps;
        }
    }

    void Jump()
    {
        myRigidbody.AddForce(new Vector2(0, jumpForce));
        anim.SetTrigger("Jump");
        JumpCount -= 1;
    }
}
