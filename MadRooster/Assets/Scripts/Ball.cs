using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    public float speed = 20;
    public int damage = 4;
    public int kickPowerX = 4;
    public int kickPowerY = 4;
    public Rigidbody2D rb;
    void Start()
    {
        rb.velocity = transform.right * speed;
        Destroy(gameObject, 4);
    }

    void OnTriggerEnter2D(Collider2D hitInfo)
    {
        Enemy enemy = hitInfo.GetComponent<Enemy>();
        Player player = hitInfo.GetComponent<Player>(); ;
        Rotation rotation = hitInfo.GetComponent<Rotation>();
        if (enemy != null && hitInfo is CircleCollider2D)
        {
            enemy.TakeDamage(damage);
            enemy.kick(kickPowerX, kickPowerY, rb);
            Destroy(gameObject);
        }




        if (rotation != null)
        {
            if (hitInfo is EdgeCollider2D)
            {
                rotation.animator.SetTrigger("deflect");
                rb.velocity *= -1;

            }
            else if (hitInfo is PolygonCollider2D)
            {
               
                rotation.TakeDamage(damage);
                rotation.kick(kickPowerX, kickPowerY, rb);
                Destroy(gameObject);
            }
        }
        else if (enemy == null && hitInfo is BoxCollider2D)
        {
            Destroy(gameObject);
        }

        if (player != null)
        {
            player.TakeDamage(damage);
            player.kick(kickPowerX, kickPowerY, rb);
            Destroy(gameObject);
        }


    }

        
}




