using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    // References to objects that the manager must track in order to handle game states:
    public GameObject player;
    public GameObject exit;
    public List<GameObject> guards = new List<GameObject>();

    private Player playerScript;
    
    // Start is called before the first frame update
    void Start()
    {
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
            // But really load the new level here.
        }
    }
}
