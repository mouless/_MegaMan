using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RollingText : MonoBehaviour
{
    public Rigidbody2D Body;
    public RollingText theTarget;

    // Use this for initialization
    void Start()
    {
        Body = GetComponent<Rigidbody2D>();

    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Body.transform.position = Vector3.MoveTowards(transform.position, new Vector2(transform.position.x, transform.position.y + 1), 1.6f * Time.deltaTime);

    }

}
