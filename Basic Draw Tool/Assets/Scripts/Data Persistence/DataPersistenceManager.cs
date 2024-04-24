using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class DataPersistenceManager : MonoBehaviour
{
    public static DataPersistenceManager instance;
    public GameData gameData;
    public List<IDataPersistance> dataPersistenceObjects;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void Start()
    {
        FindAllDataPersistenceObjects();
        LoadGame();
    }
    
    public void NewGame()
    {
        gameData = new GameData();
    }
    
    public void SaveGame()
    {
        foreach (IDataPersistance persistenceObj in dataPersistenceObjects)
        {
            persistenceObj.SaveGame(ref gameData);
        }
        
        /*
        string json = JsonUtility.ToJson(gameData);
        System.IO.File.WriteAllText(Application.persistentDataPath + "/gameData.json", json);*/
    }

    public void LoadGame()
    {
        if (gameData == null)
        {
            NewGame();
        }

        foreach (IDataPersistance persistenceObj in dataPersistenceObjects)
        {
            persistenceObj.LoadGame(gameData);
        }
        
        /*
        if (System.IO.File.Exists(Application.persistentDataPath + "/gameData.json"))
        {
            string json = System.IO.File.ReadAllText(Application.persistentDataPath + "/gameData.json");
            gameData = JsonUtility.FromJson<GameData>(json);
        }
        else
        {
            gameData = new GameData();
        }*/
    }
    
    private List<IDataPersistance> FindAllDataPersistenceObjects()
    {
        var dataPersistenceObjects = FindObjectsOfType<MonoBehaviour>().OfType<IDataPersistance>();
        
        return new List<IDataPersistance>(dataPersistenceObjects);
    }

    private void OnApplicationQuit()
    {
        SaveGame();
    }
}
