﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JustDestroy : MonoBehaviour
{

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Bullet")
        {
            Destroy(collision.gameObject);
        }
    }
}
