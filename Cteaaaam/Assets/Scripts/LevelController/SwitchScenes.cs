using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Windows;

public class SwitchScenes : MonoBehaviour
{

    void Start()
    {

    }

    void Update()
    {
        if(UnityEngine.Input.GetKeyDown(KeyCode.Alpha6)) {
            ActivateSelectionScene();
        }

        if(UnityEngine.Input.GetKeyDown(KeyCode.Alpha7))
        {
            ActivateUiScene();
        }
    }

    public void ActivateLevelOne()
    {
      SceneManager.LoadScene(4);
    }

    public void ActivateLevelTwo()
    {
        SceneManager.LoadScene(5);
    }

    public void ActivateLevelThree()
    {
        SceneManager.LoadScene(6);
    }

    public void ActivateCarShop()
    {
        SceneManager.LoadScene(1);
    }

    public void ActivateUiScene() 
    {
        SceneManager.LoadScene(0);
    }

    public void ActivateSelectionScene() 
    {
        SceneManager.LoadScene(2);
    }
    public void ActivateRecordScene()
    {
        SceneManager.LoadScene(3);
    }
    
}

