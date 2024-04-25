using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using UnityEngine.SceneManagement;

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
            DontDestroyOnLoad(this.gameObject);
        }
        else
        {
            Destroy(gameObject);
            return;
        }
        
        dataHandler = new FileDataHandler(Application.persistentDataPath, fileName);
    }

    private void OnEnable()
    {
        SceneManager.sceneLoaded += OnSceneLoaded;
        SceneManager.sceneUnloaded += OnSceneUnloaded;
    }
    
    private void OnDisable()
    {
        SceneManager.sceneLoaded -= OnSceneLoaded;
        SceneManager.sceneUnloaded -= OnSceneUnloaded;
    }
    
    private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        Debug.Log("OnScene Loaded called.");
        dataPersistenceObjects = FindAllDataPersistenceObjects();
        LoadGame();
    }
    
    private void OnSceneUnloaded(Scene scene)
    {
        Debug.Log("OnScene Unloaded called.");
        SaveGame();
    }
    
    public void NewGame()
    {
        gameData = new GameData();
    }
    
    public void SaveGame()
    {
        if (gameData == null)
        {
            Debug.Log("No game data found. New Game must be started before data can be loaded.");
            return;
        }
        
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
            Debug.Log("No game data found. New Game must be started before data can be loaded.");
            return;
        }
        
        List<IDataPersistence> tempDataPersistenceObjects = new List<IDataPersistence>(dataPersistenceObjects);

        foreach (IDataPersistence persistenceObj in tempDataPersistenceObjects)
        {
            persistenceObj.LoadData(gameData);
        }
        
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
    
    public bool HasGameData()
    {
        return gameData != null;
    }
}
