using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PregameMenu : MonoBehaviour
{
    public int CurrentLevel { get; private set; }
    
    // Start is called before the first frame update
    void Start()
    {
        //CurrentLevel = 
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void NextLevel()
    {
        //Debug.Log(gmScript.CurrentLevel);
        // Next level
        //SceneManager.LoadSceneAsync(GameManager.CurrentLevel);
    }
}
