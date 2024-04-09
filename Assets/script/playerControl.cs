using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;


public class playerControl : MonoBehaviour
{   
    
    public AudioSource gunSound;

 
    public float rotationSpeed = 5f;

   
    public float movementSpeed = 5f;

    
    public GameObject bulletPrefab;

  

    // Start is called before the first frame update
    void Start()
    {
        gunSound = GetComponent<AudioSource>();// Getcomponene Audiosource
    }

    // Update is called once per frame
    void Update()
    {

        //Retrieves the position of the cursor in the 2D 
        Vector3 cursorPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            cursorPosition.z = 0f;

            // Use the player rotation function to rotate according to the cursor.
            Rotateplayer(cursorPosition);

            //Use the player movement function
            MovePlayer();

            // Check left mouse click
            if (Input.GetMouseButtonDown(0))
            {
                // Create Bullet and Shoot
                ShootBullet(cursorPosition);
            }
        
    }
    void Rotateplayer(Vector3 targetPosition)
    {
        // Calculate the direction the player will turn.
        Vector2 direction = targetPosition - transform.position;

        //Calculate rotation angle
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;

        // Rotate the player to the calculated angle using Quaternion.Slerp.
        transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.Euler(0f, 0f,270+ angle), rotationSpeed * Time.deltaTime);
    }

    // move player function
    void MovePlayer()
    {
        
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");

        Vector2 movement = new Vector2(horizontalInput, verticalInput);
        movement.Normalize(); // Make the speed the same when pressing W+A or S+D

        // Calculate the player's new position.
        Vector3 newPosition = transform.position + new Vector3(movement.x, movement.y, 0f) * movementSpeed * Time.deltaTime;

        // Sets the player not to move outside the screen boundary.
        newPosition.x = Mathf.Clamp(newPosition.x, -8f, 8f);
        newPosition.y = Mathf.Clamp(newPosition.y, -4f, 4f);

        // move player
        transform.position = newPosition;
    }
    void ShootBullet(Vector3 targetPosition)
    {

        // Starting position of the bullet (Player's position)
        Vector3 spawnPosition = transform.position;



        // Create Bullet from Prefab
        GameObject bullet = Instantiate(bulletPrefab, (transform.position), Quaternion.identity);

        // 
        Vector2 direction = targetPosition - transform.position;
        bullet.GetComponent<BulletController>().SetDirection(direction);

        // Check if AudioSource is turned on.
        if (gunSound != null)
        {
            gunSound.Play();
        }

    }

}
