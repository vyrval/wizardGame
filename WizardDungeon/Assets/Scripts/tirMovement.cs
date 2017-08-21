using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class tirMovement : MonoBehaviour {

    public float speed;
    public int damagePoint=20;
    public float range = 100f;

    Vector3 startPosition;

    // Use this for initialization
    void Awake () {
        //Debug.Log("ball position " + transform.position);
        startPosition = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if(Vector3.Distance(startPosition, transform.position)>= range)
        {
            Destroy(gameObject);
        }
    }
    private void FixedUpdate()
    {
        transform.Translate(transform.forward * speed, Space.World);
    }

    private void OnTriggerEnter(Collider other)
    {
        //Debug.Log(gameObject.name + " hit " + other.gameObject.name);

        EnemyHealth enemyHealth = other.gameObject.GetComponent<EnemyHealth>();
        if(enemyHealth != null)
        {
            enemyHealth.TakeDamage(damagePoint);
            Destroy(gameObject);
        }

    }
}
