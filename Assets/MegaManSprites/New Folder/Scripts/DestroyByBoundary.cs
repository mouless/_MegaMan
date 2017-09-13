using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyByBoundary : MonoBehaviour
{
    public float cameraXpos;
    public GameObject typeOfEnemy;
    private bool hasSpawnedEnemy = false;
    void OnTriggerExit2D(Collider2D collision)
    {
        Debug.Log("EXIT KOLLEN");

        if (collision.gameObject.tag == "Spawner")
        {
            hasSpawnedEnemy = false;
        }
        Destroy(collision.gameObject);
        Debug.Log("Destroy bullet");
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log("ENTER INNAN IF-satsen");

        if (collision.gameObject.tag == "Spawner")
        {
            Debug.Log("ENTER EFTER IF-satsen");

            if (!hasSpawnedEnemy)
            {
                Instantiate(typeOfEnemy, (Vector2)transform.position, Quaternion.identity);
                hasSpawnedEnemy = true;
            }
        }
    }

    private void Update()
    {
        cameraXpos = transform.position.x;
    }
}
