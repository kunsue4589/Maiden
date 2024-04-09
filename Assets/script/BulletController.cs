using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletController : MonoBehaviour
{
    // bullet
    public float bulletSpeed = 10f;
    public float destroyTime = 2f;
    public int damage = 1;
    //  bulletDirection
    private Vector2 bulletDirection;


    private void Start()
    {
        StartCoroutine(DestroyBullet());
    }
    void Update()
    {
        // Move the bullet in the specified direction.
        transform.Translate(bulletDirection * bulletSpeed * Time.deltaTime);

       
       
    }
    IEnumerator DestroyBullet() 
    {
        //Wait for destroyTime and destroy the bullets.
        yield return new WaitForSeconds(destroyTime);
        Destroy(this.gameObject);
    }

    // Set the direction of the bullet.
    public void SetDirection(Vector2 direction)
    {
        bulletDirection = direction.normalized;
    }

  
  
    void OnTriggerEnter2D(Collider2D other)
    {
        // Check if Bullet collides with Enemy or not.
        if (other.CompareTag("Enemy"))
        {
            // Get Component of Enemy
            EnemyHealth enemyHealth = other.GetComponent<EnemyHealth>();

            // check EnemyHealth is not null
            if (enemyHealth != null)
            {
                // Deal damage Enemy
                enemyHealth.TakeDamage(damage);
            }

            // Destroys Bullet when colliding with Enemy.
            Destroy(gameObject);
        }
    }


}
