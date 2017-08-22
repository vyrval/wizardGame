using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShooting : MonoBehaviour {

    
    public float timeBetweenBullets = 0.15f;
    public GameObject projectileTemplate;

    float timer;
    ParticleSystem mParticles;
    Light mLight;
    float effectsDisplayTime = 0.2f;
    PlayerHealth playerHealth;

	// Use this for initialization
	void Awake () {
        mParticles = GetComponent<ParticleSystem>();
        mLight = GetComponent<Light>();
        playerHealth = GetComponentInParent<PlayerHealth>();
	}
	
	// Update is called once per frame
	void Update () {
        timer += Time.deltaTime;

        if (Input.GetButton("Fire1") && timer >= timeBetweenBullets && playerHealth.currentHealth>0)
        {
            Shoot();
        }

        if(timer >= timeBetweenBullets * effectsDisplayTime)
        {
            DisableEffects();
        }
	}

    private void Shoot()
    {
        timer = 0f;

        mLight.enabled = true;

        mParticles.Stop();
        mParticles.Play();

        GameObject go = GameObject.Instantiate(projectileTemplate,
                                                 this.transform.position,
                                                 Quaternion.identity);
        go.transform.forward = new Vector3(this.transform.forward.x,
                                            this.transform.forward.y,
                                            this.transform.forward.z);
    }

    public void DisableEffects()
    {
        mLight.enabled = false;
    }


}
