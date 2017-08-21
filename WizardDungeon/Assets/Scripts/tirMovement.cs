using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class tirMovement : MonoBehaviour {

    public float speed;

	// Use this for initialization
	void Start () {
        //Debug.Log("ball position " + transform.position);

    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(transform.forward*speed, Space.World);       
    }
}
