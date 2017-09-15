using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyTakeDamage : MonoBehaviour
{
    public bool isImmune;
    public FlyerEnemyMove bat;
    AudioSource takeDamageSound;

    private void Start()
    {
        takeDamageSound = GetComponent<AudioSource>();

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (bat != null)
        {
            isImmune = bat.iamImmune;
        }
        else
        {
            isImmune = false;
        }

        if (isImmune && collision.gameObject.tag == "Bullet")
        {
            collision.rigidbody.GetComponent<Rigidbody2D>().gravityScale = 1f;
        }
        else if (collision.gameObject.tag == "Ground")
        {
            return;
        }
        else if (collision.gameObject.tag == "Player")
        {

        }
        else if (collision.gameObject.tag == "Bullet")
        {
            Destroy(collision.gameObject);
            gameObject.GetComponent<EnemyHealth>().HurtEnemy(6f);
            takeDamageSound.Play();

        }
        else if (collision.gameObject.tag == "Enemies")
        {
            return;
        }

    }
}
