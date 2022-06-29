using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwordmanEnemyHit : MonoBehaviour
{
    public int damage = 5;
    public Animator animator;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        print("entro uno");
        if (collision.CompareTag("Player"))
        {
            animator.SetBool("IsAtacking", true);
            animator.SetFloat("Speed", 0);
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
