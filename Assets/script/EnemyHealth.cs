using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class EnemyHealth : MonoBehaviour
{
    public int maxHealth = 3;  
    private int currentHealth;  

    public int points = 1; 
    public GameController scoreManager;

    void Start()
    {
        currentHealth = maxHealth;  //Set to maximum health
        scoreManager = GameObject.FindObjectOfType<GameController>(); 
    }

    public void TakeDamage(int damage)
    {
        currentHealth -= damage;  // Reduces health based on damage taken.

        if (currentHealth <= 0)
        {
            Die();  // If the blood is 0 or less, the Die function is called.
        }
    }

    void Die()
    {
        scoreManager.AddScore(points);  //Add points
        Destroy(this.gameObject);    //Destroy!
    }
}
