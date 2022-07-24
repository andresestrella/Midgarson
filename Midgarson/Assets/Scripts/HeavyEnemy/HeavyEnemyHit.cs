using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeavyEnemyHit : MonoBehaviour
{
    public int damage = 5;
    public Animator animator;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            if (!animator.GetBool("IsDead"))
            {
                animator.SetBool("IsAtacking", true);
                animator.SetFloat("Speed", 0);
                animator.SetBool("OnHitPlayer", true);
            }
            else
            {
                animator.SetBool("IsAtacking", false);
                animator.SetFloat("Speed", 0);
                animator.SetBool("OnHitPlayer", false);
            }

            //GetComponent<BoxCollider2D>().enabled = false;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        
        if (collision.CompareTag("Player"))
        {
            animator.SetBool("IsAtacking", false);
            animator.SetBool("OnHitPlayer", false);
            //GetComponent<BoxCollider2D>().enabled = false;
        }
    }
}
