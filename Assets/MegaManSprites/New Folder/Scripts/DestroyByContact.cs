using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyByContact : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Boundary" || collision.gameObject.tag == "Player")
        {
            return;
        }
        Destroy(collision.gameObject);

    }
}
