using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{

    public GameObject gameOverPanel;


    public void PlayerDied()
    {



        ShowGameOverUI();

        // Stop the time
        Time.timeScale = 0f;

    }

    // Call function UI Game Over
    public void ShowGameOverUI()
    {
        // set active UI Game Over
        gameOverPanel.SetActive(true);
    }
}
