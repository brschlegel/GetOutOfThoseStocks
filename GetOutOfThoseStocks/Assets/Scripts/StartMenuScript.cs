using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartMenuScript : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Run()
    {
        // Pregame screen
        SceneManager.LoadSceneAsync("Level 0");
    }

    //public void NextLevel()
    //{
    //    // Level 0
    //    SceneManager.LoadSceneAsync(1);
    //}

    public void BackToMain()
    {
        // Main Menu
        SceneManager.LoadSceneAsync("Start");
    }

    public void End()
    {
        Debug.Log("quit");
        Application.Quit();
    }
}
