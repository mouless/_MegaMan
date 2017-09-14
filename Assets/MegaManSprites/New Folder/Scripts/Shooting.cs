using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooting : MonoBehaviour
{
    Animator anim;

    public float fireRate = 0;
    public float damage = 1;
    public LayerMask NotToHit;
    public GameObject bullet;
    public Vector2 offset = new Vector2(0.1f, 0.01f);
    public Vector2 offsetNeg = new Vector2(0.1f, -0.01f);
    public Vector2 velocity;

    public float maxSpeed = 10f;
    public float jumpForce = 450f;
    public bool facingRight = true;
    public Rigidbody2D Body;

    // Use this for initialization
    void Start()
    {
        Body = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
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

    private void CheckForShot()
    {
        if (true) // Check to make sure there are a maximum of 3 shots in the air at any given time
        {
            if (Input.GetKeyDown(KeyCode.X))
            {
                if (anim.GetCurrentAnimatorStateInfo(0).IsName("Player_Idle"))
                {
                    PlayerShoot();
                    Debug.Log("IDLE Shoot");
                    anim.SetTrigger("Idle_Shoot");
                }
                if (anim.GetCurrentAnimatorStateInfo(0).IsName("Player_Idle_Shoot"))
                {
                    PlayerShoot();
                    Debug.Log("IDLE Shoot");
                    anim.SetTrigger("Idle_Shoot");
                }
                else if (anim.GetCurrentAnimatorStateInfo(0).IsName("Player_Jump&Fall"))
                {
                    PlayerShoot();
                    Debug.Log("JUMPING Shoot");
                    anim.SetTrigger("Jumping_Shoot");
                    anim.Play("Player_Shoot_In_Air");
                }
                else if (anim.GetCurrentAnimatorStateInfo(0).IsName("Player_Run"))
                {
                    PlayerShoot();
                    Debug.Log("RUNNING Shoot");
                    anim.SetTrigger("Run_Shoot");
                }
                else if (anim.GetCurrentAnimatorStateInfo(0).IsName("Player_Run_Shoot"))
                {
                    PlayerShoot();
                    Debug.Log("RUNNING Shoot");
                    anim.SetTrigger("Run_Shoot");
                }
                else if (anim.GetCurrentAnimatorStateInfo(0).IsName("Player_Nudge"))
                {
                    PlayerShoot();
                    Debug.Log("NUDGE Shoot");
                    anim.SetTrigger("Idle_Shoot");
                }
            }
        }
    }

    private void PlayerShoot()
    {
        if (facingRight)
        {
            GameObject theBullet = Instantiate(bullet, (Vector2)transform.position + offset * transform.localScale.x, Quaternion.identity);
            theBullet.GetComponent<Rigidbody2D>().velocity = new Vector2(velocity.x * transform.localScale.x, velocity.y);
        }
        else
        {
            GameObject theBullet = Instantiate(bullet, (Vector2)transform.position + offsetNeg * -transform.localScale.x, Quaternion.identity);
            theBullet.GetComponent<Rigidbody2D>().velocity = new Vector2(-velocity.x * transform.localScale.x, velocity.y);
        }
    }

    void Flip()
    {
        facingRight = !facingRight;
        SpriteRenderer flipX = GetComponent<SpriteRenderer>();
        flipX.flipX = !facingRight;
    }
}
