﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class PlayerHealth : MonoBehaviour {

    public int startingHealth = 100;
    public int currentHealth;
    public Slider healthSlider;
    public Image damageImage;
    public float flashSpeed = 5f;
    public Color flashColour = new Color(1f, 0f, 0f, 0.1f);

    playerController playerMovement;
    bool isDead;
    bool damaged;
    PlayerShooting playerShooting;

    private void Awake()
    {
        playerMovement = GetComponent<playerController>();
        currentHealth = startingHealth;
        playerShooting = GetComponentInChildren<PlayerShooting>();
    }
	
	// Update is called once per frame
	void Update () {
        if (damaged)
        {
            damageImage.color = flashColour;
        }
        else
        {
            damageImage.color = Color.Lerp(damageImage.color, Color.clear, flashSpeed * Time.deltaTime);
        }
        damaged = false;
	}

    public void TakeDamage(int amount)
    {
        damaged = true;
        currentHealth -= amount;
        healthSlider.value = currentHealth;

        if(currentHealth <= 0 && !isDead)
        {
            Death();
        }
    }

    private void Death()
    {
        isDead = true;
        playerShooting.DisableEffects();
        playerMovement.enabled = false;
    }
}
