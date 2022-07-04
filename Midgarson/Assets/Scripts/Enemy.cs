using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public int rutine;
    public string name;
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
    public GameObject playerDetected, hit;
    protected float life = 100;


    public void behavor()
    {



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
                    rutine = Random.Range(0, 2);
                    chrono = 0;
                }

                switch (rutine)
                {
                    case 0:
                        //animator.SetFloat("Speed", 0);
                        break;
                    case 1:
                        direction = Random.Range(0, 2);
                        rutine++;
                        break;
                    case 2:
                        switch (direction)
                        {
                            case 0:
                                transform.Translate(Vector3.right * runSpeed * Time.deltaTime);
                                transform.rotation = Quaternion.Euler(0, 0, 0);
                                break;
                            case 1:
                                transform.Translate(Vector3.right * runSpeed * Time.deltaTime);
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


    }

    public void takeDamage(int damage)
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
                playerLife.sceneController.IncrementScore(1);
            }

            animator.SetBool("OnHit", false);
        }

    }

}
