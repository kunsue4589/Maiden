using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class goal : MonoBehaviour
{
    public bool isplayer1goal;


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("ball"))//When colliding with the ball
        {
            if(isplayer1goal) 
            {
                //If it belongs to Player 1, it will inform the game manager to increase the player 1 score.
                GameObject.Find("GameManager").GetComponent<GameManager>().player1Score();
            }
            else
            {
                //else it will inform the game manager to increase the player 2 score.
                GameObject.Find("GameManager").GetComponent<GameManager>().player2Score();
            }
        }
    }
}
