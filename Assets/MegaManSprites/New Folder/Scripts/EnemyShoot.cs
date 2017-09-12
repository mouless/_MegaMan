using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShoot : MonoBehaviour {

    public float bulletSpeed;

    public PlayerControllerScripts_Update player;

    public GameObject impactEffect;

    public float damageToGive;

    private Rigidbody2D myRigidbody2D;

	// Use this for initialization
	void Start () {
        player = FindObjectOfType<PlayerControllerScripts_Update>();

        myRigidbody2D = GetComponent<Rigidbody2D>();

        if (player.transform.position.x < transform.position.x)
        {
            bulletSpeed = -bulletSpeed;
        }
	}
	
	// Update is called once per frame
	void Update () {

        myRigidbody2D.velocity = new Vector2(bulletSpeed, myRigidbody2D.velocity.y);

	}

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            CharacterHealth.HurtPlayer(damageToGive);
        }
    }
}
