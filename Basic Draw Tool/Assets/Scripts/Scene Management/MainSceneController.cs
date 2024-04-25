using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainSceneController : MonoBehaviour
{
    [SerializeField] private Button newGameButton;
    [SerializeField] private Button continueButton;
    
    public static void ResetPlayerPrefs()
    {
        PlayerPrefs.DeleteAll();
    }
    
    public void OnNewGameButtonClicked()
    {
        DataPersistenceManager.instance.NewGame();
        SceneManager.LoadSceneAsync("DrawScene");
    }
    public void OnContinueButtonClicked()
    {
        SceneManager.LoadSceneAsync("DrawScene");
    }

    private void Start()
    {
        int isFirst = PlayerPrefs.GetInt("IsFirst");
        
        if (!DataPersistenceManager.instance.HasGameData())
        {
            PlayerPrefs.SetInt("IsFirst", 0);
            continueButton.interactable = false;
        }
        
        if (isFirst == 0)
        {
            Debug.Log("First Run");
            PlayerPrefs.SetInt("IsFirst", 1);
            //OnNewGameButtonClicked();
        }
        else
        {
            Debug.Log("Welcome Again!");
            //OnContinueButtonClicked();
        }
    }
    
    public void LoadDrawScene()
    {
        SceneManager.LoadScene("DrawScene");
    }
    
    
}
