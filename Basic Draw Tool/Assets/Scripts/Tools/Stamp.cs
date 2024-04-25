using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stamp : MonoBehaviour,IDataPersistence
{
    public GameObject stampPrefab;
    private void Awake()
    {
        // Check if the instance is null
        if (DataPersistenceManager.instance == null)
        {
            Debug.LogError("DataPersistenceManager is not initialized");
            return;
        }

        //register this object with the data persistence manager
        DataPersistenceManager.instance.RegisterDataPersistenceObject(this);
    }
    
    public void SaveData(ref GameData gameData)
    {
        if (gameData.stampPositions == null)
        {
            gameData.stampPositions = new List<Vector3>();
        }
        if (!gameData.stampPositions.Contains(transform.position))
        {
            gameData.stampPositions.Add(transform.position);
        }
    }

    public void LoadData(GameData gameData)
    {
        if (gameData.stampPositions != null)
        {
            Debug.Log("Loading " + gameData.stampPositions.Count + " stamp positions");
            foreach (Vector3 position in gameData.stampPositions)
            {
                if (!Physics.CheckSphere(position, 0.00001f))
                {
                    Debug.Log("Spawning stamp at position " + position);
                    GameObject newStamp = Instantiate(stampPrefab, position, Quaternion.identity);
                    if (newStamp == null)
                    {
                        Debug.LogError("Failed to spawn stamp at position " + position);
                    }
                    else
                    {
                        Debug.Log("Successfully spawned stamp at position " + position);
                    }
                }
                else
                {
                    Debug.Log("An object already exists at position " + position);
                }
            }
        }
        else
        {
            Debug.Log("No stamp positions to load");
        }
    }
    /*
    public void SaveData(ref GameData gameData)
    {
        if (gameData.stampPositions == null)
        {
            gameData.stampPositions = new List<Vector3>();
        }
        gameData.stampPositions.Add(transform.position);
        
        //save the prefab type for generating the correct prefab when loading
        
    }
    
    public void LoadData(GameData gameData)
    {
        if (gameData.stampPositions != null)
        {
            Debug.Log("Loading " + gameData.stampPositions.Count + " stamp positions");
            foreach (Vector3 position in gameData.stampPositions)
            {
                Debug.Log("Spawning stamp at position " + position);
                GameObject newStamp = Instantiate(stampPrefab, position, Quaternion.identity);
                if (newStamp == null)
                {
                    Debug.LogError("Failed to spawn stamp at position " + position);
                }
            }
        }
        else
        {
            Debug.Log("No stamp positions to load");
        }
    }*/
}

