using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicEnemyRange : MonoBehaviour
{
    public Animator animator;
    BasicEnemy BasicEnemy;

    private void Awake()
    {
        BasicEnemy = GameObject.Find("Enemy").GetComponent<BasicEnemy>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        
        if (collision.CompareTag("Player"))
        {
                if (transform.position.x < collision.transform.position.x)
                {
                    animator.SetFloat("Speed", BasicEnemy.runSpeed);

                    BasicEnemy.transform.rotation = Quaternion.Euler(0, 0, 0);
                    BasicEnemy.transform.Translate(Vector3.right * BasicEnemy.runSpeed * Time.deltaTime);
                    
                    animator.SetBool("IsAtacking", false);
                }
                else
                {
                
                    animator.SetFloat("Speed", BasicEnemy.runSpeed);
                    BasicEnemy.transform.rotation = Quaternion.Euler(0, 180, 0);
                    BasicEnemy.transform.Translate(Vector3.right * BasicEnemy.runSpeed * Time.deltaTime);
                    
                    animator.SetBool("IsAtacking", false);
                }
            
        }

    }

    private void Start()
    {
        
    }
}
