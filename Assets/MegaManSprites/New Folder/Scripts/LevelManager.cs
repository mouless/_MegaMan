﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    public GameObject currentCheckpoint;

    private PlayerControllerScripts_Update player;

    // Use this for initialization
    void Start()
    {
        player = FindObjectOfType<PlayerControllerScripts_Update>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void RespawnPlayer()
    {
        Debug.Log("Player RESPAWN!!");
        player.transform.position = currentCheckpoint.transform.position;
    }


}
