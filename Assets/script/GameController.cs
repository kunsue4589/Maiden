using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using TMPro;
using UnityEngine;


public class GameController : MonoBehaviour
{
    [Header("ScoreManager")] 
    public TextMeshProUGUI scoreText;
    private int score = 0;



    [Header("EnemySpawner")] 
    public GameObject enemyPrefab;
    public GameObject playerPrefab; 
    public float spawnInterval = 1f;
    float circleRadius = 10f;  


    public GameObject gameOverPanel;




    private bool playerIsActive = true;

    void Start()
    {
       
        Time.timeScale = 1f; //make time normal

        StartCoroutine(SpawnEnemies());// start spawn Enemy

        UpdateScoreUI(); //Adjust the score


        // close UI Game Over
        gameOverPanel.SetActive(false);

    }

    public void AddScore(int points)
    {
        score += points;//add point
        UpdateScoreUI();//Adjust the score
    }

    void UpdateScoreUI()
    {
        scoreText.text = "Score: " + score.ToString();//Adjust the score
    }

    IEnumerator SpawnEnemies()
    {
        while (true)
        {
            // Wait time according to spawnInterval
            yield return new WaitForSeconds(spawnInterval);

            Vector2 circleCenter = new Vector2(0f, 0f);  //Center position of the circle

            Vector2 newPosition = new Vector2(Random.Range(-11f, 11f), Random.Range(-12f, 12f)); //Calculate the spawn point

            while (Vector2.Distance(newPosition, circleCenter) <= circleRadius)// if spawn point is smaller then circleRadius
            {
                newPosition = new Vector2(Random.Range(0f, 10f), Random.Range(0f, 10f));
            }

            //Check whether the player is still activated or not.
            if (playerIsActive)
            {
                //Instantiate by specifying prefab, position, and rotation
                GameObject spawnedObject = Instantiate(enemyPrefab, newPosition, Quaternion.identity);
            }

          
        }
    }

    //Function that will be called when the player die
    public void PlayerDied()
    {
        playerIsActive = false;

        // Delete all prefab Enemy
        GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy");
        foreach (GameObject enemy in enemies)
        {
            Destroy(enemy);
        }

     

        ShowGameOver(); // show UI GameOver

        // Stop time
        Time.timeScale = 0f;

    }




    //Run it when you want to open the Game Over UI.
    public void ShowGameOver()
    {
        //Open UI Game Over
        gameOverPanel.SetActive(true);
    }

  

}