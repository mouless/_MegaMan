﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{

    public float currentEnemyHealth;
    public float maxEnemyHealth;

    // Use this for initialization
    void Start()
    {
        currentEnemyHealth = maxEnemyHealth;
    }

    public void HurtEnemy(float damageTaken)
    {
        currentEnemyHealth -= damageTaken;

        if (currentEnemyHealth <= 0)
        {
            EnemyDeath();
        }
        PlaySound();
    }

    private void PlaySound()
    {
        
    }

    private void EnemyDeath()
    {
        currentEnemyHealth = 0;
        Debug.Log("ENEMY IS DEAD!!!");
        Destroy(gameObject);
    }
}
