using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public void ExitApplication()
    {
        Application.Quit();
    }
    
    public void LoadWelcomeScene()
    {
        //TODO will be edited
        PlayerPrefs.DeleteAll();
        SceneManager.LoadScene("WelcomeScene");
    }
}
