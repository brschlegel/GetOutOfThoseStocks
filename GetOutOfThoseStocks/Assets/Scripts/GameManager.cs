using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;  //< Scene loading
using UnityEngine.UI;               //< UI Text

public class GameManager : MonoBehaviour
{
    // References to objects that the manager must track in order to handle gameplay and states:
    public int CurrentLevel { get; private set; }
    private float timeScale;
    public GameObject player;
    public GameObject exit;
    public Text gameOverText;
    public List<GameObject> guards = new List<GameObject>();

    private Player playerScript;
    
    // Start is called before the first frame update
    void Start()
    {
        // Text derives from MonoBehaviour.
        gameOverText.gameObject.SetActive(false);

        // currentLevel must follow build indexing, and cannot be hard-coded.
        CurrentLevel = SceneManager.GetActiveScene().buildIndex;

        playerScript = player.GetComponent<Player>();
    }

    // Update is called once per frame
    /// @pre if Time.timeScale == 0 FixedUpdate() is NOT called - pausing/unpausing handled here.
    private void Update()
    {
        // Check for win/lose conditions:
        if (playerScript.caught)
        {
            // Pause game and give player option to restart.
            Time.timeScale = 0;
            gameOverText.gameObject.SetActive(true);

            // Upon press of R, unfreeze game, reset player boolean flags and reload level.
            if (playerScript.caught && Input.GetKeyDown(KeyCode.R))
            {
                playerScript.ResetFlags();
                Time.timeScale = 1;

                // Do not increment and, instead, reload the current level.
                SceneManager.LoadSceneAsync(CurrentLevel);
            }
        }
        // These are mutually exclusive - use elif.
        else if (playerScript.exited)
        {
            // Reset flags, then increment and load the next level.
            playerScript.ResetFlags();
            SceneManager.LoadSceneAsync(++CurrentLevel);
        }
    }

    // Deprecated in favour of Update()
    void FixedUpdate()
    {
        //Debug.Log(playerScript.caught);
        
        //// Check for win/lose conditions:
        //if (playerScript.caught)
        //{
        //    Debug.Log("caught");

        //    // But really stop the game and prompt to restart here.

        //    Debug.Log("pausing");
        //    // Save the current timeScale for use later when the game unpauses.
        //    timeScale = Time.timeScale;
        //    Time.timeScale = 0;
        //    Debug.Log("paused");

        //    // TODO: GUI saying press R to restart or something
        //    gameOverText.gameObject.SetActive(true);

        //}
        //// These are mutually exclusive - use elif.
        //else if (playerScript.exited)
        //{
        //    Debug.Log("exited");

        //    // Increment and load the next level.
        //    SceneManager.LoadSceneAsync(++currentLevel);
        //}
        
        //if (playerScript.caught && Input.GetKeyDown(KeyCode.R))
        //{
        //    Debug.Log("restart");
        //    Time.timeScale = timeScale;
        //    // Do not increment and reload the current level.
        //    SceneManager.LoadSceneAsync(currentLevel);
        //}
    }
}