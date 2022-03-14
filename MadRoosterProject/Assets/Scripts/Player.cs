using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class Player : MonoBehaviour
{
    public Animator animator;
    public float moveSpeed = 5f;
    public float jumpHeight;
    public Transform groundCheck;
    public float groundCheckRadius;
    public LayerMask WhatIsGround;
    public Transform startPoint;
    public int maxHealth = 100;
    public int currentHealth;
    public HealthBar healthBar;
    

    public int number = 5;
    public TextMeshProUGUI view;

    public bool grounded;
    private bool transformAnim = true;
    private bool doubleJump = true;

    void Start()
    {
        currentHealth = maxHealth;
        healthBar.SetMaxHealth(maxHealth);
    }

    void FixedUpdate()
    {
        grounded = Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, WhatIsGround);
    }

    private void Update()
    {
        animator.SetFloat("moveSpeed", Mathf.Abs(Input.GetAxis("Horizontal")));
        animator.SetBool("Grounded", grounded);



        if (animator.GetCurrentAnimatorStateInfo(0).IsName("FireToWater") ||
            animator.GetCurrentAnimatorStateInfo(0).IsName("WaterToFire") ||
            animator.GetCurrentAnimatorStateInfo(0).IsName("DefaultToFire")||
            animator.GetCurrentAnimatorStateInfo(0).IsName("DefaultToWater"))
        {
            transformAnim = false;
        }
        else transformAnim = true;

        if (animator.GetCurrentAnimatorStateInfo(0).IsName("default_damage"))
        {
            GetComponent<Rigidbody2D>().velocity = Vector2.zero;
            return;
        }

        if (transformAnim)
        {
            if (Input.GetAxis("Horizontal") > 0.01f)
            {
                transform.rotation = new Quaternion(0, 0, 0, 0);
            }
            else if (Input.GetAxis("Horizontal") < -0.01f)
            {
                transform.rotation = new Quaternion(0, 180, 0, 0);
            }
            transform.position += new Vector3(Input.GetAxis("Horizontal") * Time.deltaTime * moveSpeed, 0, 0);

            if (grounded && (Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.UpArrow)))
            {
                GetComponent<Rigidbody2D>().velocity = new Vector2(0, jumpHeight);
                doubleJump = true;
            }
            else if (doubleJump && (Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.UpArrow)))
            {
                GetComponent<Rigidbody2D>().velocity = new Vector2(0, jumpHeight);
                doubleJump = false;
            }
        }

        if(transform.position.y < - 10) TakeDamage(100); 




        if (currentHealth <= 0) restartPlayer();
        if (number <= 0) SceneManager.LoadScene(3);




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

    public void restartPlayer()
    {
        gameObject.transform.position = new Vector2(startPoint.position.x, startPoint.position.y+1);
        healthBar.SetHealth(maxHealth);
        currentHealth = maxHealth;
        Decrement();
    }

    public void Decrement()
    {
        number--;
        view.text = number.ToString();
    }

}
