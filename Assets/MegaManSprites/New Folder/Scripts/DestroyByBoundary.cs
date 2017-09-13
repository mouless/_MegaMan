using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyByBoundary : MonoBehaviour
{
    public float cameraXpos;
    public GameObject typeOfEnemy;
    public Spawner hasSpawned;
    //private bool hasSpawnedEnemy = false;

    void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "Enemies")
        {
            hasSpawned = FindObjectOfType<Spawner>();
            hasSpawned.hasSpawnedEnemy = false;
            Debug.Log("TRY TO SET TO FALSE!!!");
            Destroy(collision.gameObject);
        }
        Destroy(collision.gameObject);
        Debug.Log("Destroy bullet");
    }

    private void Update()
    {
        cameraXpos = transform.position.x;
    }
}
