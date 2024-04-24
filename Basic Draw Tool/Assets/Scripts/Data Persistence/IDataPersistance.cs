using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IDataPersistance
{
    void SaveGame(ref GameData gameData);
    
    void LoadGame(GameData gameData);
}
