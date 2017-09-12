using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletWithBullet : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Bullet")
        {
            collision.rigidbody.GetComponent<Rigidbody2D>().gravityScale = 2f;
        }
        else
        {
            return;
        }
    }
}
