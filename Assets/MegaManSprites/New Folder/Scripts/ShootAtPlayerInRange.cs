using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootAtPlayerInRange : MonoBehaviour {

    public float playerRange;

    public GameObject enemyProjectile;

    public PlayerControllerScripts_Update player;

    public Transform launchPoint;


	// Use this for initialization
	void Start () {
        player = FindObjectOfType<PlayerControllerScripts_Update>();
        
	}
	
	// Update is called once per frame
	void Update () {
        Debug.DrawLine (new Vector3(transform.position.x - playerRange, transform.position.y, transform.position.z), new Vector3(transform.position.x + playerRange, transform.position.y, transform.position.z));

        if ((transform.localScale.x < 0) && (player.transform.position.x > transform.position.x) && (player.transform.position.x < transform.position.x + playerRange))
        {
            Instantiate(enemyProjectile, launchPoint.position, launchPoint.rotation);
        }

        if ((transform.localScale.x > 0) && (player.transform.position.x < transform.position.x) && (player.transform.position.x > transform.position.x - playerRange))
        {
            Instantiate(enemyProjectile, launchPoint.position, launchPoint.rotation);
        }

    }
}
