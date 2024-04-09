using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEditor.FilePathAttribute;

public class Ball : MonoBehaviour
{
    public float speed;
    public Rigidbody2D rb;
    private Vector3 startPosition;

    // Start is called before the first frame update
    void Start()
    {
        startPosition = transform.position;//set start position
        Lunch();//call Lunch function 
    }
    private void Lunch()
    {
        //Randomize where the ball will be released.
        float x = Random.Range(0,2) == 0 ? -1 : 1 ;
        float y = Random.Range(0, 2) == 0 ? -1 : 1;
        rb.velocity = new Vector2(speed * x,speed * y);
    }
    public void Reset()
    {
        //Reset the location and call Lunch function 
        rb.velocity = Vector2.zero;
        transform.position = startPosition;
        Lunch();
    }
}
