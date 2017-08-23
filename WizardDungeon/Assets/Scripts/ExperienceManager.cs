using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ExperienceManager : MonoBehaviour {

    public Text text;
    public static uint currentExperience;

    // Use this for initialization
    void Awake () {
        currentExperience = 0;	
	}
	
	// Update is called once per frame
	void Update () {
        text.text = "XP: "+ currentExperience; 
	}



    
}
