using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class miniEnemy : MonoBehaviour
{
    private Animator animator;
    
    public float speed;
    public Transform pointA;  
    public Transform pointB;  
    private SpriteRenderer spriteRenderer;
    private bool isRight = true;
    private bool movingTowardsA = true;
    public player players;

    void Start()
    {
        //Getcomponent
       spriteRenderer = GetComponent<SpriteRenderer>();
        animator = GetComponent<Animator>();

        animator.SetBool("run", true);//set animation
        players = FindObjectOfType<player>();// find player
    }

    // Update is called once per frame
    void Update()
    {
       
        if (movingTowardsA)
        {
            MoveTowards(pointA);//move to point A
        }
        else
        {
            MoveTowards(pointB);// move to point B
        }
    }

    void MoveTowards(Transform target)
    {
       
        transform.position = Vector2.MoveTowards(transform.position, target.position, speed * Time.deltaTime);

        //If the Enemy has reached its destination point Switch direction to another point.
        if (Vector2.Distance(transform.position, target.position) < 1f)
        {
            movingTowardsA = !movingTowardsA;
            Flip();

        }
    }
    void Flip()
    {
        //flip perfab
        isRight = !isRight;
        spriteRenderer.flipX = !isRight;
    }

  
}
