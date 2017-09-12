using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CharacterHealth : MonoBehaviour
{
    public float currentHealth;
    public float maxHealth;

    static public Slider healthbar;

    // Use this for initialization
    void Start()
    {
        maxHealth = 100f;
        currentHealth = maxHealth;
        healthbar.value = currentHealth;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Z))
        {
            HurtPlayer(6.66f);
        }
    }

    public void HurtPlayer(float damageTaken)
    {
        currentHealth -= damageTaken;

        if (currentHealth <= 0)
        {
            PlayerDeath();
        }

        UpdateHealthBar();
    }

    private void PlayerDeath()
    {
        currentHealth = 0;
        Debug.Log("YOU'RE DEAD!!!");
    }

    private void UpdateHealthBar()
    {
        healthbar.value = currentHealth / 100;
    }
}
