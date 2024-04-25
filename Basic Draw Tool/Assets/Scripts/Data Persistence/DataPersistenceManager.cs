using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class DataPersistenceManager : MonoBehaviour
{
    [Header("File Storage Configuration")]
    
    [SerializeField] private string fileName;
    
    private FileDataHandler dataHandler;
    
    private GameData gameData;

    private List<IDataPersistence> dataPersistenceObjects;
    public static DataPersistenceManager instance {get; private set;}
    
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
        dataHandler = new FileDataHandler(Application.persistentDataPath, fileName);
        dataPersistenceObjects = FindAllDataPersistenceObjects();
        LoadGame();
    }
    
    public void NewGame()
    {
        gameData = new GameData();
    }
    
    public void SaveGame()
    {
        foreach (IDataPersistence persistenceObj in dataPersistenceObjects)
        {
            persistenceObj.SaveData(ref gameData);
        }
        
        dataHandler.Save(gameData);
    }

    public void LoadGame()
    {
        gameData = dataHandler.Load();
        
        if (gameData == null)
        {
            Debug.Log("No game data found. Initializing data to defaults.");
            NewGame();
        }
        
        List<IDataPersistence> tempDataPersistenceObjects = new List<IDataPersistence>(dataPersistenceObjects);

        foreach (IDataPersistence persistenceObj in tempDataPersistenceObjects)
        {
            persistenceObj.LoadData(gameData);
        }
        
        /*
        foreach (IDataPersistence persistenceObj in dataPersistenceObjects)
        {
            persistenceObj.LoadData(gameData);
        }*/
        
    }
    
    private List<IDataPersistence> FindAllDataPersistenceObjects() 
    {
        // FindObjectsofType takes in an optional boolean to include inactive gameobjects
        IEnumerable<IDataPersistence> persistenceObjects = FindObjectsOfType<MonoBehaviour>(true)
            .OfType<IDataPersistence>();

        return new List<IDataPersistence>(persistenceObjects);
    }
    
    public void RegisterDataPersistenceObject(IDataPersistence dataPersistenceObject)
    {
        if (dataPersistenceObjects == null)
        {
            dataPersistenceObjects = new List<IDataPersistence>();
        }

        dataPersistenceObjects.Add(dataPersistenceObject);
    }

    private void OnApplicationQuit()
    {
        SaveGame();
        Debug.Log("Game data saved before quitting.");
    }
}
