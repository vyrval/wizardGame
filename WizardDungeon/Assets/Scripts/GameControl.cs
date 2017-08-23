using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;
using System;

public class GameControl : MonoBehaviour {

    //Singleton like pattern
    public static GameControl controlInstance;

    public uint experience;


    private String fileName= "/playerInfo.dat";

	// Use this for initialization
	void Awake () {
        if (controlInstance == null)
        {
            controlInstance = this;
            DontDestroyOnLoad(gameObject);
        }
        else if(controlInstance != this)
        {
            Destroy(gameObject);
        }    
	}

    private void Update()
    {
        if (Input.GetButtonDown("Jump"))
        {
            Save();
        }
        if (Input.GetButtonDown("Fire3"))
        {
            Load();
        }
    }

    public void Save()
    {
        BinaryFormatter bf = new BinaryFormatter();
        FileStream file = File.Create(Application.persistentDataPath + fileName);

        PlayerData data = new PlayerData();
        data.experience = ExperienceManager.currentExperience;

        bf.Serialize(file,data);
        file.Close();

        Debug.Log("Saved!");
    }

    public void Load()
    {
        if (File.Exists(Application.persistentDataPath + fileName))
        {
            BinaryFormatter bf = new BinaryFormatter();
            FileStream file = File.Open(Application.persistentDataPath + fileName, FileMode.Open);

            PlayerData data = (PlayerData)bf.Deserialize(file);
            ExperienceManager.currentExperience = data.experience;

            Debug.Log("Loaded!");
        }
    }
}

[Serializable]
class PlayerData
{
    public uint experience;

    public PlayerData() { }
    public PlayerData(uint exp)
    {
        experience = exp;
    }
}
