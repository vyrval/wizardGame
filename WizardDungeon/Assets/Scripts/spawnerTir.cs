using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spawnerTir : MonoBehaviour {
    public GameObject projectileTemplate;
    public GlobalVars gamemanager;
 

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

 


	}

    public void fireIt()
    {
        GameObject go = GameObject.Instantiate(projectileTemplate, 
                                                this.transform.position, 
                                                Quaternion.identity);
        go.transform.forward = new Vector3(this.transform.forward.x,
                                            this.transform.forward.y,
                                            this.transform.forward.z);
        gamemanager.projectiles.Add(go);

        //Debug.Log("spawner position "+transform.position);
    }

}
