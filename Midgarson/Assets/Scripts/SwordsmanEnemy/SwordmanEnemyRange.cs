using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwordmanEnemyRange : MonoBehaviour
{
    public Animator animator;


    private void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.CompareTag("Player") && !animator.GetBool("IsDead"))
        {
            animator.SetBool("IsOnRange", true);
        }

    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player") && !animator.GetBool("IsDead"))
        {
            animator.SetBool("IsOnRange", false);
        }
    }

    private void Start()
    {
        
    }
}
