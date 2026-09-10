using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.SceneManagement; //you need to add this to access scene stuff

public class InterfaceStuff : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

//We are going to use the OnClick() to run this function for the pause button
    public void DoAPause(){
        if (Time.timeScale == 1f){ //if the game is NOT paused
            Time.timeScale = 0f; //pause the game
        } else if (Time.timeScale == 0f){ //if it is already paused...
            Time.timeScale = 1f; //unpause the game
        }
    }

//We are going to use the OnClick() to run this function to load the scene specified in the string
    public void LoadAScene(string sceneToLoad){
        SceneManager.LoadScene(sceneToLoad);
    }
}
