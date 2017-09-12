using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyByBoundary : MonoBehaviour
{
    public float cameraXpos;

    void OnTriggerExit2D(Collider2D collision)
    {
        Destroy(collision.gameObject);
        Debug.Log("Destroy bullet");
    }
    
    private void Update()
    {
        cameraXpos = transform.position.x;
    }
}
