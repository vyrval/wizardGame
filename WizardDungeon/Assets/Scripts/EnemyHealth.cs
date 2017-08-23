using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour {

    public int startingHealth = 100;
    public int currentHealth;
    public float sinkSpeed = 2.5f;
    public int experienceValue = 10;

    CapsuleCollider capsuleCollider;
    bool isDead;
    bool isSinking;

	// Use this for initialization
	void Awake () {
        capsuleCollider = GetComponent<CapsuleCollider>();

        currentHealth = startingHealth;
    }
	
	// Update is called once per frame
	void Update () {
        if (isSinking)
        {
            transform.Translate(-Vector3.up * sinkSpeed * Time.deltaTime);
        }
	}

    public void TakeDamage(int amount)
    {
        if (isDead)
        {
            return;
        }

        currentHealth -= amount;
        if (currentHealth <= 0)
        {
            Death();
        }
        //Debug.Log(gameObject.name + "'s life = " + currentHealth);
    }

    void Death()
    {
        isDead = true;
        capsuleCollider.isTrigger = true;

        ExperienceManager.currentExperience += (uint)experienceValue;
        Debug.Log(gameObject.name + "'s exp value = " + experienceValue);
        StartSinking();
    }

    public void StartSinking()
    {
        GetComponent<UnityEngine.AI.NavMeshAgent>().enabled = false;
        GetComponent<Rigidbody>().isKinematic = true;
        isSinking = true;

        Destroy(gameObject, 2f);
    }
}
