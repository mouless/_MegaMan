using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LadderZone : MonoBehaviour {

    private PlayerControllerScripts_Update thePlayer;

	// Use this for initialization
	void Start () {
        thePlayer = FindObjectOfType<PlayerControllerScripts_Update>();
	}

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.name == "Player")
        {
            thePlayer.onLadder = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.name == "Player")
        {
            thePlayer.onLadder = false;
        }
    }
}
