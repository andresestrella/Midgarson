using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwordmanEnemyRange : MonoBehaviour
{
    public Animator animator;
    SwordmanEnemy SwordmanEnemy;

    private void Awake()
    {
        SwordmanEnemy = GameObject.Find("Enemy").GetComponent<SwordmanEnemy>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        
        if (collision.CompareTag("Player"))
        {
                if (transform.position.x < collision.transform.position.x)
                {
                    animator.SetFloat("Speed", SwordmanEnemy.runSpeed);

                    SwordmanEnemy.transform.rotation = Quaternion.Euler(0, 0, 0);
                    SwordmanEnemy.transform.Translate(Vector3.right * SwordmanEnemy.runSpeed * Time.deltaTime);
                    
                    animator.SetBool("IsAtacking", false);
                }
                else
                {
                
                    animator.SetFloat("Speed", SwordmanEnemy.runSpeed);
                    SwordmanEnemy.transform.rotation = Quaternion.Euler(0, 180, 0);
                    SwordmanEnemy.transform.Translate(Vector3.right * SwordmanEnemy.runSpeed * Time.deltaTime);
                    
                    animator.SetBool("IsAtacking", false);
                }
            
        }

    }

    private void Start()
    {
        
    }
}
