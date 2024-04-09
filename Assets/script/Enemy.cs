using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Enemy : MonoBehaviour
{

    public float speed = 5f;  
    private Transform player; 
    private Rigidbody2D rb;  
    public float rotationSpeed = 5f;  


    void Start()
    {


        rb = GetComponent<Rigidbody2D>();  // Getcomponent Rigidbody2D 

    }
    void Update()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;  // find Transform of Player
        MoveTowardsPlayer();
    }

    void MoveTowardsPlayer()
    {
        // Calculate the direction the Enemy will move.
        Vector2 direction = player.position - transform.position;
        direction.Normalize();  // Make the length of the vector equal to 1.

        // Move Enemy in the calculated direction.
        rb.MovePosition(rb.position + direction * speed * Time.deltaTime);

        // Turn face towards the Player.
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        float currentAngle = Mathf.LerpAngle(rb.rotation, angle + 270, rotationSpeed * Time.deltaTime);
        rb.MoveRotation(currentAngle);
    }
    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            // If Enemy hits the Player, call the "suicide" function.
            Suicide();
        }
    }


    void Suicide()
    {
        // Destroy Enemy when hit by Player.
        Destroy(this.gameObject);
    }
}
