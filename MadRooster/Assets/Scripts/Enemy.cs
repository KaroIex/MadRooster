using System.Collections;
using System.Collections.Generic;
using System.Net.NetworkInformation;
using UnityEngine;


public class Enemy : MonoBehaviour
{
    public int currentHealth = 100;
    public HealthBar healthBar; 
    public Transform Player;
    public Transform healthBarRotation;
    public int Speed = 5;
    public Transform viewPointUP;
    public Transform viewPointDown;
    public Transform Right;
    public Transform Left;
    public Transform FireUp;
    public Transform FireDown;
    public Animator animator;
    bool flag = true;
    public Transform groundCheck;
    public float groundCheckRadius = 0.1f;
    public LayerMask WhatIsGround;
    public float speed;
    Vector3 oldPosition;
    public bool CanIShoot = false;


    bool time = true;

    public float distance;
    float random;






    private bool grounded;



    public int maxHealth;
    void Start()
    {
        currentHealth = maxHealth;
        healthBar.SetMaxHealth(maxHealth);
    }
    void FixedUpdate()
    {
        grounded = Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, WhatIsGround);
    }
    void Update()
    {
       

        if (time)
        {
            StartCoroutine("StartPulsing");
            random = Random.Range(1, 7);
        }

        if (currentHealth <= 0) Destroy(gameObject);

        animator.SetFloat("Speed", speed);
        speed = Vector3.Distance(oldPosition, transform.position);
        oldPosition = transform.position;
        animator.SetBool("Grounded", grounded);

        if (Vector2.Distance(transform.position, Player.position) < 10  && (Player.position.y <= viewPointUP.position.y && Player.position.y >= viewPointDown.position.y))
        {
            if (transform.position.x > Player.position.x)
            {
                CanIShoot = false;
                distance = random;

                transform.rotation = new Quaternion(0, 180, 0, 0);
                healthBarRotation.rotation = new Quaternion(0, 180, 0, 0);
            }
            else if (transform.position.x < Player.position.x)
            {

                    distance = -random;

                CanIShoot = false;
                transform.rotation = new Quaternion(0, 0, 0, 0);
                healthBarRotation.rotation = new Quaternion(0, 0, 0, 0);
            }

            transform.position = Vector2.MoveTowards((new Vector2(transform.position.x, transform.position.y)), (new Vector2(Player.position.x + distance, transform.position.y)), Speed * Time.deltaTime);
            if(transform.position.y < FireUp.position.y && transform.position.y > FireDown.position.y)
            CanIShoot = true;
        }
        else
        {

            if (transform.position.x <= Right.position.x && flag)
            {
                if (transform.position.x == Right.position.x)
                {
                    flag = false;
                    transform.rotation = new Quaternion(0, 180, 0, 0);
                    healthBarRotation.rotation = new Quaternion(0, 180, 0, 0);
                }

                GetComponent<Collider2D>().offset = new Vector2(-GetComponent<Collider2D>().offset.x, GetComponent<Collider2D>().offset.y); 
                transform.rotation = new Quaternion(0, 0, 0, 0);
                healthBarRotation.rotation = new Quaternion(0, 0, 0, 0);
                transform.position = Vector2.MoveTowards((new Vector2(transform.position.x, transform.position.y)), (new Vector2(Right.position.x, transform.position.y)), Speed * Time.deltaTime);
            }
            else if (transform.position.x > Left.position.x)
            {
                transform.position = Vector2.MoveTowards((new Vector2(transform.position.x, transform.position.y)), (new Vector2(Left.position.x, transform.position.y)), Speed * Time.deltaTime);
                transform.rotation = new Quaternion(0, 180, 0, 0);
                healthBarRotation.rotation = new Quaternion(0, 180, 0, 0);
                GetComponent<Collider2D>().offset = new Vector2(GetComponent<Collider2D>().offset.x, GetComponent<Collider2D>().offset.y);
            }
            else
            {
                flag = true;
                //transform.position = Vector2.MoveTowards((new Vector2(transform.position.x, transform.position.y)), (new Vector2(Left.position.x, transform.position.y)), Speed * Time.deltaTime);
            }


            CanIShoot = false;
        }

 


    }
    public void TakeDamage(int damage)
    {
        currentHealth -= damage;
        healthBar.SetHealth(currentHealth);
       
    }
    public void kick(int kickPowerX, int kickPowerY, Rigidbody2D axe)
    {

        if (axe.velocity.x > 0)
            GetComponent<Rigidbody2D>().velocity = new Vector2(kickPowerX, kickPowerY);
        else GetComponent<Rigidbody2D>().velocity = new Vector2(-kickPowerX, kickPowerY);

    }
    void OnTriggerEnter2D(Collider2D other)
    {
        if (grounded)
        {
            if(other.gameObject.name != "Player")
            GetComponent<Rigidbody2D>().velocity = new Vector2(0, 8);




   
        }
    }


    void OnTriggerStay2D(Collider2D other)
    {
        if (grounded)
        {
   
                GetComponent<Rigidbody2D>().velocity = new Vector2(0, 8);





        }
        // GetComponent<Rigidbody2D>().velocity = new Vector2(0, 8);
    }
    private IEnumerator StartPulsing()
    {
        time = false;
        yield return new WaitForSeconds(0.3f);
        time = true;

    }
}





