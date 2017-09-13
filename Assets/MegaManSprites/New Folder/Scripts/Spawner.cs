using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject typeOfEnemy;
    private bool hasSpawnedEnemy = false;
    private void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log("ENTER AREA");
        if (!hasSpawnedEnemy && collision.gameObject.tag == "Player")
        {
            GameObject hare = Instantiate(typeOfEnemy, (Vector2)transform.position, Quaternion.identity) as GameObject;
            hasSpawnedEnemy = true;
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        Debug.Log("EXIT AREA");
        if (collision.gameObject.tag == "Player")
        {
            hasSpawnedEnemy = false;
        }
    }
}
