using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class Enemy : MonoBehaviour
{
    public long? id;
    public int rutine;
    public new EnemyTag name;
    public int damage;
    public float chrono = 0;
    float chrono2 = 0;
    public Animator animator;
    public float walkSpeed = 2f, runSpeed = 6f;
    public GameObject target;
    public float direction;
    public PlayerLife playerLife;
    public float enemyBounds = 8;
    public float atackRange = 2;
    public float life = 100;
    public bool isDead = false;
    public float currPosX;
    public float currPosY;
    public GameObject item;



    public Enemy()
    { /*
        this.name = name;
        this.damage = damage;
        this.life = life;
        this.isDead = isDead;
        */
    }

    public GameObject playerDetected, hit;
    //protected float life = 100;



    public void behavor()
    {

        if (isDead)
        {
            animator.SetBool("IsDead", true);
            animator.SetBool("IsAtacking", false);
            animator.SetFloat("Speed", 0);
            animator.SetBool("OnHitPlayer", false);
            gameObject.GetComponent<Rigidbody2D>().simulated = false;
            chrono += 1 * Time.deltaTime;
            if (chrono >= 2)
            {
                //Destroy(gameObject);
                //gameObject.active = false;
                chrono = 0;

            }
            
        }

        if (!animator.GetBool("IsDead"))
        {

            if (animator.GetBool("OnHitPlayer"))
            {
                playerLife.TakeDamage(damage);
                animator.SetBool("OnHitPlayer", false);


            }
            chrono2 += 1 * Time.deltaTime;
            if (chrono2 >= 1 && animator.GetBool("IsAtacking"))
            {
                chrono2 = 0;
                animator.SetBool("OnHitPlayer", true);
            }

            if (!animator.GetBool("IsOnRange") && !animator.GetBool("IsAtacking"))
            {
                //animator.SetFloat("Speed", 0);
                chrono += 1 * Time.deltaTime;
                if (chrono >= 4)
                {
                    rutine = UnityEngine.Random.Range(0, 2);
                    chrono = 0;
                    
                }

                switch (rutine)
                {
                    case 0:
                        //animator.SetFloat("Speed", 0);
                        break;
                    case 1:
                        direction = UnityEngine.Random.Range(0, 2);
                        rutine++;
                        break;
                    case 2:
                        switch (direction)
                        {
                            case 0:
                                //transform.Translate(Vector3.right * runSpeed * Time.deltaTime);
                                transform.rotation = Quaternion.Euler(0, 0, 0);
                                break;
                            case 1:
                                //transform.Translate(Vector3.right * runSpeed * Time.deltaTime);
                                transform.rotation = Quaternion.Euler(0, 180, 0);
                                break;
                        }


                        animator.SetFloat("Speed", walkSpeed);
                        break;

                }
            }
            else if (!animator.GetBool("IsAtacking"))
            {
                if (transform.position.x < target.transform.position.x)
                {
                    transform.Translate(Vector3.right * runSpeed * Time.deltaTime);
                    transform.rotation = Quaternion.Euler(0, 0, 0);
                }
                else
                {
                    transform.Translate(Vector3.right * runSpeed * Time.deltaTime);
                    transform.rotation = Quaternion.Euler(0, 180, 0);
                }
                animator.SetFloat("Speed", runSpeed);

            }



        }
        else
        {
            if (item != null)
            {
                DropItem();
                item = null;
            }
        }


    }

    public void takeDamage(int damage)
    {
        

        if(!name.Equals(EnemyTag.Archery) && !name.Equals(EnemyTag.Boss) )
        {
            if (!animator.GetBool("IsDead"))
            {
                life -= damage;
                animator.SetBool("OnHit", true);
                if (life <= 0.0)
                {
                    animator.SetBool("IsDead", true);
                    animator.SetBool("IsAtacking", false);
                    animator.SetFloat("Speed", 0);
                    animator.SetBool("OnHitPlayer", false);
                    isDead = true;
                    //transform.position = new Vector3(transform.position.x, transform.position.y, 10);
                    gameObject.GetComponent<Rigidbody2D>().simulated = false;
                    playerLife.sceneController.IncrementScore(1);

                }

                animator.SetBool("OnHit", false);
            }
        }
        else
        {
            if (!isDead)
            {
                life -= damage;
                if(life <= 0.0)
                {
                    isDead = true;
                    //Destroy(gameObject);
                    //gameObject.active = false;

                    //transform.position = new Vector3(transform.position.x, transform.position.y,10);
                    gameObject.GetComponent<Rigidbody2D>().simulated = false;
                    if (item != null)
                    {
                        DropItem();
                        item = null;
                    }
                    playerLife.sceneController.IncrementScore(1);
                    
                }

            }
            
        }
        

    }

    public void DropItem()
    {
        Vector3 position = transform.position;
        Instantiate(item, position, Quaternion.identity);
    }

}
