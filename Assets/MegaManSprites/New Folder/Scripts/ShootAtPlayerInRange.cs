using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootAtPlayerInRange : MonoBehaviour
{

    public float playerRange;

    public GameObject enemyProjectile;

    public PlayerControllerScripts_Update player;

    public Transform launchPoint;

    public float waitBetweenShots;

    private float shotCounter;

    private bool facingLeft;


    // Use this for initialization
    void Start()
    {
        player = FindObjectOfType<PlayerControllerScripts_Update>();
        facingLeft = true;
        shotCounter = waitBetweenShots;

    }

    // Update is called once per frame
    void Update()
    {
        Debug.DrawLine(new Vector3(transform.position.x - playerRange, transform.position.y, transform.position.z), new Vector3(transform.position.x + playerRange, transform.position.y, transform.position.z));

        shotCounter -= Time.deltaTime;

        if (player.transform.position.x > transform.position.x && player.transform.position.x < transform.position.x + playerRange)
        {
            if (facingLeft)
                Flip();
            if (shotCounter < 0)
            {
                Instantiate(enemyProjectile, launchPoint.position, launchPoint.rotation);
                shotCounter = waitBetweenShots;
            }
        }

        if (player.transform.position.x < transform.position.x && player.transform.position.x > transform.position.x - playerRange)
        {
            if (!facingLeft)
                Flip();
            if (shotCounter < 0)
            {
                Instantiate(enemyProjectile, launchPoint.position, launchPoint.rotation);
                shotCounter = waitBetweenShots;
            }
            // transform.localScale.x > 0 &&  -- använd bara om enemy is moving???
        }
    }
    void Flip()
    {
        facingLeft = !facingLeft;
        SpriteRenderer flippyX = GetComponent<SpriteRenderer>();
        flippyX.flipX = !facingLeft;
    }
}
