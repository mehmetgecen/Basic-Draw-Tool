using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainSceneController : MonoBehaviour
{
    public static void ResetPlayerPrefs()
    {
        PlayerPrefs.DeleteAll();
        //EditorApplication.ExitPlaymode();
    }
    
    
    //check if user played for the first time
    private void Start()
    {
        int isFirst = PlayerPrefs.GetInt("IsFirst");
        if (isFirst == 0)
        {
            Debug.Log("First Run");
            PlayerPrefs.SetInt("IsFirst", 1);
            Invoke(nameof(LoadDrawScene), 4f);
        }
        else
        {
            Debug.Log("Welcome Again!");
            SceneManager.LoadScene(1);
        }
    }
    
    public void LoadDrawScene()
    {
        SceneManager.LoadScene("DrawScene");
    }
    
    
}
