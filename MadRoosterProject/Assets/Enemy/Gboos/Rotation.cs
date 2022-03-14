using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;
using System.Security.Cryptography;
using System.Collections.Specialized;
using System.Net.NetworkInformation;
using Random = UnityEngine.Random;
public class Rotation : MonoBehaviour
{
    public AIPath aiPath;
    public Transform Player;
    public HealthBar healthBar;
    public int currentHealth = 1000;
    public int maxHealth = 1000;
    public Transform firePoint;
    public AIDestinationSetter aIDestinationSetter;
    public Transform newTarget;
    public Transform Me;
    public AstarPath juz_mam_dosc;
    public Seeker seeker;
    public Transform groundCheck;
    public float groundCheckRadius = 0.1f;
    public LayerMask WhatIsGround;
    public bool CanIShoot;
    public Transform viewPointUP;
    public Transform viewPointDown;
    public Animator animator;
    public bool isCutscene;
    public Transform aPotemTu;
    public float Speed;
    public float speed;
    public float distance;
    public Player script;
    bool TRYBII = false;
    bool patrzajDobrze = false;
    bool flag1 = false;
    bool flag2 = false;
    bool flag3 = false;
    bool flag4 = false;
    Vector3 oldPosition;
    bool tryb3 = false;
    bool tryb4 = false;
    bool coronatimeXD = true;
    bool time = true;
    float random;
    bool flag5 = false;

    bool grounded;

    void Start()
    {
        currentHealth = maxHealth;
        healthBar.SetMaxHealth(maxHealth);
    }


    void Update()
    {

        animator.SetFloat("speed", speed);
        speed = Vector3.Distance(oldPosition, transform.position);
        oldPosition = transform.position;



        if (currentHealth <= 0)
        {
            Destroy(gameObject);
        }


        if (currentHealth <= 500 && flag1 == false)
        {
            patrzajDobrze = true;
            isCutscene = true;
            aIDestinationSetter.target = newTarget;
            aIDestinationSetter.flaga = false;
            transform.localScale = new Vector3(1.3f, 1.3f, 1.3f);
            flag1 = true;
            CanIShoot = false;
        }

        if (Vector2.Distance(newTarget.position, transform.position) < 10 && flag2 == false)
        {
            juz_mam_dosc.enabled = false;
            aIDestinationSetter.enabled = false;
            seeker.enabled = false;
            aiPath.enabled = false;
            aIDestinationSetter.target = null;
            TRYBII = true;
            flag2 = true;
            CanIShoot = false;
            animator.SetBool("tryb2", true);
        }
        if (TRYBII == false)
        {
            if ((transform.position.x < Player.position.x) && patrzajDobrze == false)
            {
                transform.localScale = new Vector3(1.3f, 1.3f, 1.3f);
                firePoint.rotation = Quaternion.Euler(0, 0, 0);
            }
            else if ((transform.position.x >= Player.position.x) && patrzajDobrze == false)
            {
                transform.localScale = new Vector3(-1.3f, 1.3f, 1.3f);
                firePoint.rotation = Quaternion.Euler(0, 180, 0);
            }

            if (transform.position.y <= viewPointUP.position.y && transform.position.y >= viewPointDown.position.y && flag1 == false)
                CanIShoot = true;
            else CanIShoot = false;
        }





        if (TRYBII == true)
        {
            grounded = Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, WhatIsGround);
            animator.SetBool("GroundCheck", grounded);
            CanIShoot = false;
            if (flag3 == false)
                transform.position = Vector2.MoveTowards((new Vector2(transform.position.x, transform.position.y)), (new Vector2(aPotemTu.position.x, transform.position.y)), Speed * Time.deltaTime);
        }

        if (Vector2.Distance(aPotemTu.position, transform.position) < 2f && flag3 == false)
        {
            flag3 = true;
            tryb3 = true;
            CanIShoot = false;
            this.GetComponent<Collider2D>().GetComponent<EdgeCollider2D>().enabled = true;
            this.GetComponent<Collider2D>().GetComponent<BoxCollider2D>().enabled = true;

        }


        if (tryb3 == true)
        {
            if (coronatimeXD)
            {
                StartCoroutine("StartPulsing");

            }

            transform.localScale = new Vector3(-1.3f, 1.3f, 1.3f);
            if (flag4 == false)
            {
                animator.SetBool("transformacja", true);
                flag4 = true;
            }
            else animator.SetBool("transformacja", false);
            tryb4 = true;
        }




        if (tryb4 == true && Vector2.Distance(transform.position, Player.position) < 20)
        {

            if (Vector2.Distance(transform.position, Player.position) == 2 && flag5 == false)
            {

                script.TakeDamage(10);
                flag5 = true;
            }
            else { flag5 = false; }


            if (time)
            {
                StartCoroutine("Delay", 0.4f);
                random = Random.Range(2, 8);
            }


            if ((transform.position.x < Player.position.x))
            {
                distance = -random;
                transform.localScale = new Vector3(1.3f, 1.3f, 1.3f);

            }
            else if ((transform.position.x >= Player.position.x))
            {
                distance = random;
                transform.localScale = new Vector3(-1.3f, 1.3f, 1.3f);

            }


            transform.position = Vector2.MoveTowards((new Vector2(transform.position.x, transform.position.y)), (new Vector2(Player.position.x + distance, transform.position.y)), Speed * Time.deltaTime);

        }


    }

    public void TakeDamage(int damage)
    {
        currentHealth -= damage;
        healthBar.SetHealth(currentHealth);

    }

    public void kick(int kickPowerX, int kickPowerY, Rigidbody2D axe)
    {
        if (tryb3 == true)
        {

            if (axe.velocity.x > 0)
                GetComponent<Rigidbody2D>().velocity = new Vector2(kickPowerX, kickPowerY);
            else GetComponent<Rigidbody2D>().velocity = new Vector2(-kickPowerX, kickPowerY);
        }

    }

    private IEnumerator StartPulsing()
    {
        coronatimeXD = false;
        yield return new WaitForSeconds(1f);
        isCutscene = false;
        coronatimeXD = true;

    }

    private IEnumerator Delay(float d)
    {
        time = false;
        yield return new WaitForSeconds(d);
        time = true;

    }


    void OnTriggerEnter2D(Collider2D hitInfo)
    {
        Player player = hitInfo.GetComponent<Player>(); ;
        if (player != null)
        {
            animator.SetTrigger("swordAtack");
            player.TakeDamage(5);
        }
    }




}



