using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class TextController : MonoBehaviour
{
    public List<Text> storyTextList;
    private int clickCounter;
    
    // Start is called before the first frame update
    void Start()
    {
        clickCounter = 0;
    }

    // Update is called once per frame
    void Update()
    {
        // Advance story upon LMB click.
        if (Input.GetMouseButtonDown(0))
            clickCounter++;

        // Once intro is complete, begin the game.
        if (clickCounter >= storyTextList.Count)
            SceneManager.LoadSceneAsync("Level 0");

        // Hide all Text objects, except the one corresponding to clickCounter.
        foreach (Text storyText in storyTextList)
            storyText.gameObject.SetActive(false);

        storyTextList[clickCounter].gameObject.SetActive(true);
    }
}
