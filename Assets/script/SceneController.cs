using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadSceneButton : MonoBehaviour
{

    // Create a function that will be called when the button is clicked.
    public void RetryButton()
    {
        // Load the specified scene.
        SceneManager.LoadScene("Shooter");
    }

    public void ExitButton()
    {
        //Load the specified scene.
        SceneManager.LoadScene("Lobby");
    }
    public void StartButton()
    {
        //Load the specified scene.
        SceneManager.LoadScene("Shooter");
    }
    public void QuitButton()
    {
        //Exit Game
        Application.Quit();
    }
   
}