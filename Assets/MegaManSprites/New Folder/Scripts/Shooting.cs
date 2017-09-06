using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooting : MonoBehaviour
{
    Animator anim;

    public float fireRate = 0;
    public float damage = 1;
    public LayerMask NotToHit;
    public GameObject bullet;
    public Vector2 offset = new Vector2(0.4f, 0.4f);
    //public int canShoot = 3;

    Transform firePoint;

    // Use this for initialization
    void Start()
    {
        anim = GetComponent<Animator>();

    }

    // Update is called once per frame
    void Update()
    {
        if (fireRate == 0)
        {
            CheckForShot();

        }
    }

    private void CheckForShot()
    {
        if (true) // Check to make sure there are maximum 3 shots in the air at any given time
        {
            if (Input.GetKeyDown(KeyCode.X))
            {
                // FIRE EVERYTHING!!!
                Debug.Log("FIRE EVERYTHING!!!");
                //Instantiate(bullet, (Vector2)transform.position + offset * transform.localScale.x, Quaternion.identity);
                anim.SetBool("Idle_Shoot", false);

            }
        }
    }
}
