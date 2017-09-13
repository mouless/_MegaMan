using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject typeOfEnemy;
    public bool hasSpawnedEnemy = false;
    public GameObject theEnemy;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (!hasSpawnedEnemy && collision.tag == "Player")
        {
            theEnemy = Instantiate(typeOfEnemy, (Vector2)transform.position, Quaternion.identity);
            hasSpawnedEnemy = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (theEnemy == null && collision.tag == "Player")
        {
            hasSpawnedEnemy = false;
        }
    }
}
