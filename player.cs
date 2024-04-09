using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class player : MonoBehaviour
{
    [Header("Movement")]
    public Rigidbody2D myRigidbody;
    public float moveSpeed = 10f;
    private bool isRight = true;

    [Header("Jump")]
    private bool isGrounded = true;
    public float jumpForce = 50f;
    public LayerMask groundLayer;
    public float groundCheckRadius = 1f;
    private int jumpCount = 1;

 
   

    [Header("Attack")]
    public Transform attackPoint;
    public float attackRange = 0.5f;
    public LayerMask enemyLayers;
    public float attackRate = 2f;
    float attacknext = 0f;


    [Header("HP")]
    public float maxHealth = 100; 
    private float currentHealth; 
    public bool isDead = false; 

    [Header("HP BAR")]
    public RectTransform uiTransform;
    public float lerpSpeed = 5f;


   
    public Animator animator;
    public GameManager gameManager;
    SpriteRenderer spriteRenderer;
 
    
    void Start()
    {
        myRigidbody = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();


        currentHealth = maxHealth; // Set the currentHealth  to be equal to the maxhealth.

    }

    // Update is called once per frame
    void Update()
    {
        if(!isDead)
        {
            if (Time.time >= attacknext)  // count the time until the next attack 
            {
                if (Input.GetKeyDown(KeyCode.Space))
                {
                    Attack(); //Call the function
                    attacknext = Time.time + 1f / attackRate;  //To calculate the time until the next attack
                }
            }


            PlayerMovement();  //Call the function
        }

        UpdateUI();  //Call the function


    }
  

    void Attack()
    {
        //set animation  attack
        animator.SetTrigger("attack");



        //collect all enemies within the attack position and attack range
        Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(attackPoint.position, attackRange, enemyLayers);

        foreach (Collider2D enemy in hitEnemies)
        {
            
            Debug.Log("we hit " + enemy.name);
           
        }
    }
    void OnDrawGizmosSelected()
    {
        //Draw a mock-up of the attack range.
        Gizmos.color = Color.red;//color
        Gizmos.DrawWireSphere(attackPoint.position, attackRange);//WireSphere based on the attack position and attack range.


        //Draw a mock-up of the ground check range.
        Gizmos.color = Color.white;//color
        Gizmos.DrawWireSphere(transform.position, groundCheckRadius);//WireSphere based on transform.position and groundCheckRadius
    }

    private void PlayerMovement()
    {

        /////// Movement//////////


        float horizontalInput = Input.GetAxis("Horizontal");//Keep input horizontal
        Vector2 movement = new Vector2(horizontalInput * moveSpeed, myRigidbody.velocity.y); //Calculate movement from stored input
        myRigidbody.velocity = movement;//"Perform movement."





        // to switch between idle and run animations
        if (horizontalInput != 0)
        {
            animator.SetBool("run", true); 
        }

        else
        {
            animator.SetBool("run", false);
        }


        if (horizontalInput < 0 && isRight)
        {
            Flip();
        }
        else if (horizontalInput > 0 && !isRight)
        {

            Flip();
        }


        ///////Movement///////


        ///////Jump///////
        isGrounded = Physics2D.OverlapCircle(transform.position, groundCheckRadius, groundLayer);  //Calculate the distance to the ground

        if (jumpCount >0 && Input.GetKeyDown(KeyCode.W))  //conditionIf the jumpCount is greater than 0 you can jump
        {
            jumpCount--;  //reduce jumpCount 
            myRigidbody.velocity = new Vector2(myRigidbody.velocity.x, jumpForce);  //calculate the jumping distance
            Debug.Log("jump");

            // call jumpAnimation
            animator.SetTrigger("jump");
         

        }
        if (isGrounded) 
        {
            //if you touch Ground jumpCount will = 1
            jumpCount = 1;
        }

        if (!isGrounded) //to set anmation fall
        {
            animator.SetBool("isGround", false);
        }
        else
        {
            animator.SetBool("isGround", true);
        }


        ///////Jump///////
    }

    void Flip()
    {
        isRight = !isRight;   //Toggle the boolean value between true and false
        if (isRight)
        {
            transform.rotation = Quaternion.Euler(0f, 0f, 0f); // To rotate to the right (0 degrees)
        }
        else
        {
            transform.rotation = Quaternion.Euler(0f, 180f, 0f); // To rotate to the left(180 degrees)
        }
    }


    void OnCollisionEnter2D(Collision2D collision)  //when collisionEnter
    {
        if (collision.gameObject.CompareTag("Enemy")) //if that collision have "Enemy" tag
        {

         
            TakeDamage(20); //Call the function

        }
    }


    public void TakeDamage(int damage)
    {
        currentHealth -= damage;  // Reduce health according to the specified damage
        animator.SetTrigger("dammaged"); //to set anmation dammaged
        if (currentHealth <= 0)
        {


            
            Die(); // If the health decreases to 0, the player dies
            animator.SetBool("isdead", true);  //to set anmation isdead
            isDead = true;


        }
    }
    void Die()
    {
        StartCoroutine(DieWithDelay());
    }

    IEnumerator DieWithDelay()
    {
        yield return new WaitForSeconds(2f); // WaitFor 2 Seconds

        //Notify the gameManager that the player has died
        gameManager.PlayerDied();  //Call the function
    }

    

    void UpdateUI()
    {
        // Adjust the X-scale of the UI according to the health value
        float scaleFactorX = currentHealth / maxHealth; // Adjust the X-scale to be within the range of 0 to 1
        float targetScaleX = Mathf.Lerp(scaleFactorX, uiTransform.localScale.x,  Time.deltaTime * lerpSpeed);  //Calculate the UI adjustment and smoothness
        uiTransform.localScale = new Vector3(targetScaleX, uiTransform.localScale.y, uiTransform.localScale.z); //adjust the UI
    }
    
}