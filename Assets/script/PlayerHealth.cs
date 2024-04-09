using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PlayerHealth : MonoBehaviour
{
    public float maxHealth = 100; 
    private float currentHealth; 
    public   bool isDead = false; 

  
    public GameController gameController;

    [Header("HP Bar")]

    public RectTransform uiTransform;
    public float lerpSpeed = 5f;


    void Start()
    {
        currentHealth = maxHealth; // Set the starting health value to be equal to the maximum health value.
    }

    void Update()
    {
        UpdateUI();// run UpdateUI function
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            // If a player collides with an Enemy, their health is reduced.
            TakeDamage(20); //Reduce blood by 20 units
        }
    }

    // Function to reduce health
    void TakeDamage(int damage)
    {
        currentHealth -= damage; //Reduces blood based on specified damage.


        if (currentHealth <= 0)
        {
           
           
                isDead = true;
                Die(); //If the health drops to 0 the player dies.




        }
    }



    // Function called when a player dies.
    void Die()
    {
        //Notify GameController Know that the player has died.
        gameController.PlayerDied();

         

        gameObject.SetActive(false);
    }
  
    void UpdateUI()
    {
        // Adjust the UI's Y scale according to Health values.
        float scaleFactorY = currentHealth / maxHealth; //Adjust the Y scale to be in the range 0-1.
        float targetScaleY = Mathf.Lerp(uiTransform.localScale.y, scaleFactorY, Time.deltaTime * lerpSpeed);
        uiTransform.localScale = new Vector3(uiTransform.localScale.x, targetScaleY, uiTransform.localScale.z);
    }
}