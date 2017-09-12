using System;
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
        maxEnemyHealth = 12f;
        currentEnemyHealth = maxEnemyHealth;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.A))
        {
            DealDamage(6.66f);
        }
    }

    public void DealDamage(float damageTaken)
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
