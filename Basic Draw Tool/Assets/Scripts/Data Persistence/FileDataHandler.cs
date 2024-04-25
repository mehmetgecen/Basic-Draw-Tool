using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System;

public class FileDataHandler : MonoBehaviour
{
    private string dataDirPath = "";
    private string dataFileName = "";

    public FileDataHandler(string dataDirPath, string dataFileName)
    {
        this.dataDirPath = dataDirPath;
        this.dataFileName = dataFileName;
    }

    public GameData Load()
    {
        //combine directory path and file name for different OS' path seperators.
        string fullPath = Path.Combine(dataDirPath, dataFileName);
        
        GameData loadedData = null;

        if (File.Exists(fullPath))
        {
            try
            {
                string dataToLoad = "";
            
                //read json data from file
                using (FileStream stream = new FileStream(fullPath, FileMode.Open))
                {
                    using (StreamReader reader = new StreamReader(stream))
                    {
                        dataToLoad = reader.ReadToEnd();
                    }
                }
            
                //deserialize json data to game data
                loadedData = JsonUtility.FromJson<GameData>(dataToLoad);
            }
            catch (Exception e)
            {
                Debug.LogError("Error occured when loading data from file : " + fullPath + "\n" + e);
            
            }
        }
        
        return loadedData;

    }
    
    public void Save(GameData data)
    {
        //combine directory path and file name for different OS' path seperators.
        string fullPath = Path.Combine(dataDirPath, dataFileName);

        try
        {
            //create directory if it doesn't exist
            Directory.CreateDirectory(Path.GetDirectoryName(fullPath));
            
            //serialize game data to json
            string dataToStore = JsonUtility.ToJson(data,true);

            
            //write json data to file
            using (FileStream stream = new FileStream(fullPath, FileMode.Create))
            {
                using (StreamWriter writer = new StreamWriter(stream))
                {
                    writer.Write(dataToStore);
                }
            }
            
        }
        catch (Exception e)
        {
            Debug.LogError("Error occured when saving data to file : " + fullPath + "\n" + e);
        }
    }





}
