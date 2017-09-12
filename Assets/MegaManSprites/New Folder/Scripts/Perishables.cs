using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Perishables : MonoBehaviour
{
    public float lifeInSeconds;

    private void Update()
    {
        lifeInSeconds -= 1.0F * Time.deltaTime;
        if (lifeInSeconds <= 0)
        {
            Destroy(gameObject);
        }
    }
}
