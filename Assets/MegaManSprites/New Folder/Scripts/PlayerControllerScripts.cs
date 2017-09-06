using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControllerScripts : MonoBehaviour
{
    public float maxSpeed = 10f;
    public float jumpForce;
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

    // Update is called at the same time as the physics engine
    void FixedUpdate()
    {
        float move = Input.GetAxis("Horizontal");
        Body.velocity = new Vector2(move * maxSpeed, Body.velocity.y);

        anim.SetFloat("Speed", Mathf.Abs(move));
        _Input();

        // Make sure that the character is facing the way he's moving
        if (move > 0 && !facingRight)
        {
            Flip();
        }
        else if (move < 0 && facingRight)
        {
            Flip();
        }

        //If the character is falling, animate the falling sprites
        if (myRigidbody.velocity.y < 0)
        {
            anim.SetTrigger("Falling");
            anim.SetBool("Land", true);
        }
        else
        {
            anim.SetBool("Land", false);
            // TEST
        }
    }

    void Flip()
    {
        facingRight = !facingRight;
        SpriteRenderer flipX = GetComponent<SpriteRenderer>();
        flipX.flipX = !facingRight;
    }

    void _Input()
    {
        if (JumpCount > 0)
        {
            if (Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(KeyCode.UpArrow))
            {
                Jump();
            }
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Ground")
        {
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
