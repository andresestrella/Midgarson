using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwordmanEnemyHit : MonoBehaviour
{
    public int damage = 5;
    public Animator animator;
    public PlayerLife playerLife = new PlayerLife();

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            animator.SetBool("IsAtacking", true);
            animator.SetFloat("Speed", 0);
            playerLife.TakeDamage(damage);
            //GetComponent<BoxCollider2D>().enabled = false;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        
        if (collision.CompareTag("Player"))
        {
            animator.SetBool("IsAtacking", false);
            
            //GetComponent<BoxCollider2D>().enabled = false;
        }
    }
}
