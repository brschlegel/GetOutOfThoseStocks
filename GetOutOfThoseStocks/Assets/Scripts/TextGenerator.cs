using System; // Enum.Parse
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TextGenerator : MonoBehaviour
{
    enum Levels
    {
        FIRST,
        SECOND,
        THIRD,
        FOURTH,
        FIFTH,
        SIXTH
    }
    
    public Text header;
    public GameObject gameManager;
    private GameManager gmScript;
    
    // Start is called before the first frame update
    void Start()
    {
        gmScript = gameManager.GetComponent<GameManager>();
    }

    // Update is called once per frame
    void Update()
    {
        header.text = string.Format("STARTING LEVEL THE {0}", (Levels)gmScript.CurrentLevel);
    }
}
