using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicEnemy : MonoBehaviour
{
    public int rutine;
    public float chrono;
    public Animator animator;
    float walkSpeed = 2f,runSpeed = 6f;
    public GameObject target;
    public float direction;

    public float enemyBounds = 8;
    public float atackRange = 2;
    public GameObject playerDetected,hit;


    private void Awake()
    {
        animator = GetComponent<Animator>();
    }

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        target = GameObject.FindGameObjectWithTag("Player");

    }

    // Update is called once per frame
    void Update()
    {
        behavor();
    }

    public void behavor()
    {
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
        else if(!animator.GetBool("IsAtacking"))
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
