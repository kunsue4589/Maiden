using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player1and2 : MonoBehaviour
{
    public bool isPlayer1;
    public float speed;
    private Rigidbody2D rb;
    private float movement;
    private Vector3 startPosition;


    private void Start()
    {
        startPosition = transform.position; //set start position
        rb = GetComponent<Rigidbody2D>(); 
    }
    void Update()
    {
        if(isPlayer1)
        {
            //If it belongs to Player 1, can move by press W/S
            movement = Input.GetAxisRaw("Vertical");
        }
        else
        {
            //else can move by press UP DOWN
            movement = Input.GetAxisRaw("Vertical2");
        }
        rb.velocity = new Vector2 (rb.velocity.x, movement*speed);//Calculate movement
    }
    public void Reset()
    {
        //Reset player
        rb.velocity = Vector2.zero;
         transform.position = startPosition ;
    }
}
