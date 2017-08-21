using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class killProj : MonoBehaviour {
    public GlobalVars GameManager;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag.Equals("Proj"))
            GameManager.killGO(collision.gameObject, GameManager.projectiles);
        //Debug.Log(this.gameObject.name + ": Collide with "+ collision.gameObject.name);
    }

}
