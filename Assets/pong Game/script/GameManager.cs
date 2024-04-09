using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [Header("ball")]
    public GameObject ball;

    [Header("player1")]
    public GameObject player1;
    public GameObject goal1;

    [Header("player2")]
    public GameObject player2;
    public GameObject goal2;

    [Header("score")]
    public GameObject player1text;
    public GameObject player2text;

    private int player1score;
    private int player2score;

    public void player1Score()
    {
        //Reset position and increase score to player 1
        player1score++;
        player1text.GetComponent<TextMeshProUGUI>().text = player1score.ToString();
        ResetPosition();

    }
    public void player2Score()
    {
        //Reset position and increase score to player 2
        player2score++;
        player2text.GetComponent<TextMeshProUGUI>().text = player2score.ToString();
        ResetPosition();

    }
    private void ResetPosition()
    {
        //Reset position ball player 1 and player 2
        ball.GetComponent<Ball>().Reset();
        player1.GetComponent<player1and2>().Reset();
        player2.GetComponent<player1and2>().Reset();
    }
}
