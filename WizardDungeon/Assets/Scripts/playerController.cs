using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerController : MonoBehaviour {

    public float speed;
    public spawnerTir spawn;

    private Vector3 lastdir;
    Rigidbody playerRig;
    int floorMask;
    float camRayLength=100f;
    Vector3 movement;

	// Use this for initialization
	void Start () {
        speed = 5;
        //rb = GetComponent<Rigidbody>();

	}

    private void Awake()
    {
        floorMask = LayerMask.GetMask("Floor");
        playerRig = GetComponent<Rigidbody>();
    }


    // Update is called once per frame
    void Update () {
        if(Input.GetButtonDown("Fire1"))
        {
            spawn.fireIt();
            //Debug.Log("player position " + transform.position);

        }

    }

    private void FixedUpdate()
    {

        float h = Input.GetAxisRaw("Horizontal");
        float v = Input.GetAxisRaw("Vertical");

        Move(h, v);

    }

    private void Move(float h, float v)
    {
        movement.Set(h, 0f, v);
        movement = movement.normalized * speed * Time.deltaTime;
        playerRig.MovePosition(transform.position + movement);

        //Rotates the player to make him face the direction he's heading to
        if (!movement.Equals(Vector3.zero))
        {
            Quaternion newRotation = Quaternion.LookRotation(movement.normalized);
            playerRig.MoveRotation(newRotation);
        }
        
    }

}
