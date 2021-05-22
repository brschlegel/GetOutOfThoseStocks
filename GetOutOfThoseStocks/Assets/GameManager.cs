using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    // References to objects that the manager must track in order to handle game states:
    private int currentLevel;
    public GameObject player;
    public GameObject exit;
    public List<GameObject> guards = new List<GameObject>();

    private Player playerScript;
    
    // Start is called before the first frame update
    void Start()
    {
        currentLevel = 1;
        playerScript = player.GetComponent<Player>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        // Check for win/lose conditions:
        if (playerScript.caught)
        {
            Debug.Log("caught");
            // But really stop the game and prompt to restart here.
        }
        // These are mutually exclusive - use elif.
        else if (playerScript.exited)
        {
            Debug.Log("exited");

            // Increment and load the next level.
            SceneManager.LoadSceneAsync(++currentLevel);
        }
    }
}