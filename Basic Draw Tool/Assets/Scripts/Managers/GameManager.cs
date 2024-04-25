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
        PlayerPrefs.SetInt("IsFirst", 0);
        SceneManager.LoadScene("WelcomeScene");
    }
}
