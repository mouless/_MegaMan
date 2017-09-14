using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CharacterHealth : MonoBehaviour
{
    public static float currentHealth;
    public float maxHealth;

    private LevelManager levelManager;

    public Slider healthbar;

    // Use this for initialization
    void Start()
    {
        healthbar = GetComponent<Slider>();
        levelManager = FindObjectOfType<LevelManager>();

        maxHealth = 100f;
        currentHealth = maxHealth;
        healthbar.value = currentHealth;
    }

    // Update is called once per frame
    void Update()
    {
        if (currentHealth <= 0)
        {
            FullHealth();
            levelManager.RespawnPlayer();
        }

        if (Input.GetKeyDown(KeyCode.Z))
        {
            HurtPlayer(6.66f);
        }

        UpdateHealthBar();

    }

    public static void HurtPlayer(float damageTaken)
    {
        currentHealth -= damageTaken;
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

    public void FullHealth()
    {
        currentHealth = maxHealth;
    }
}
