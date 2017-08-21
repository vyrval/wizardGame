using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GlobalVars : MonoBehaviour {
    public List<GameObject> projectiles = new List<GameObject>();
    public GameObject player;


    private void Update()
    {
        List<int> tokill = new List<int>();
        for (int i = 0; i < projectiles.Count; i++)
        {
            GameObject go = projectiles[i];
            float dist = Vector3.Distance(Vector3.zero, go.transform.position);
            if (dist > 100)
            {
                tokill.Add(i);
            }
        }
        foreach (int goID in tokill)
        {
            killGO(projectiles[goID], this.projectiles);
        }
    }

    public void killGO(GameObject go, List<GameObject> list)
    {
        if (list.Contains(go))
        {
            list.Remove(go);
            GameObject.Destroy(go);
            //Debug.Log("Object killed");
        }
    }
}
