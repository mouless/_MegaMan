using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyByContact : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Boundary" || collision.gameObject.tag == "Player" || collision.gameObject.tag == "Bullet")
        {
            if (collision.gameObject.tag == "Bullet")
            {
                collision.rigidbody.GetComponent<Rigidbody2D>().gravityScale = 1f;
            }
            return;
        }
        else
        {
            Destroy(collision.gameObject);
        }
    }
}
