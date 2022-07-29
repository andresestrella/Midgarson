using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovBoss5 : Enemy
{
    public Rigidbody2D rg;
    public Transform player;
    public bool observandoDerecha = true;

    public float damageTaken = 0.9f;

    public Animator otherAnimator;
    public float simpleAttackRange = 9f;

    public GameObject knife;
    public float timeToshoot, countDown;

    int rutina;

    [SerializeField] private float vida;

    [Header("Ataque")]
    [SerializeField] private Transform controladorAtaque;
    [SerializeField] private float radioAtaque;
    [SerializeField] private float danoAtaque;
    [SerializeField] private float jumpForce = 5f;

    public bool dash;
    public float timeDash;
    public float velocityDash;
    float ditanciaPlayer;

    private void Awake()
    {
        playerLife = GameObject.Find("Player 1").GetComponent<PlayerLife>();
    }
    void Start()
    {
        name = EnemyTag.Boss;
        animator = GetComponent<Animator>();
        rg = GetComponent<Rigidbody2D>();
        player = GameObject.Find("Player 1").GetComponent<Transform>();
        countDown = timeToshoot;

    }
    void Update()
    {
        if (isDead)
        {
            gameObject.GetComponent<Rigidbody2D>().simulated = false;
        }
        else
        {
            ditanciaPlayer = Vector2.Distance(transform.position, player.position);
            animator.SetFloat("DistanciaPlayer", ditanciaPlayer);


            if (ditanciaPlayer > 10)
            {
                animator.SetBool("isWalking", false);
            }
            else
            {
                chrono += 1 * Time.deltaTime;



                if (chrono >= Random.Range(1, 2))
                {
                    rutina = Random.Range(0, 3);
                    chrono = 0;
                }

                if (rutina <= 1)
                {
                    animator.SetBool("isWalking", true);
                    if (ditanciaPlayer > 7)
                    {
                        Dash_skill();
                    }

                    if (ditanciaPlayer > 5 && ditanciaPlayer < 7)
                    {
                        print("jump");
                        Jump();
                    }

                }
                if (rutina > 1)
                {
                    countDown -= Time.deltaTime;

                    if (countDown < 0)
                    {
                        animator.SetBool("isWalking", false);
                        ShootPlayer(!observandoDerecha);
                        countDown = timeToshoot;

                    }
                    else
                    {
                        animator.SetBool("isWalking", true);

                    }



                }
            }


        }




    }

    void Dash_skill()
    {
        timeDash += 1 * Time.deltaTime;

        if (timeDash < 0.35f)
        {
            dash = true;
            animator.SetBool("Dash", true);
            transform.Translate(Vector3.right * velocityDash * Time.fixedDeltaTime);
        }
        else
        {
            dash = false;
            animator.SetBool("Dash", false);
        }
    }

    void Jump()
    {
        rg.AddForce(new Vector2(transform.position.x, jumpForce), ForceMode2D.Impulse);
        // animator.SetBool("Jump", true);
    }


    public void MirarPlayer()
    {
        if ((player.position.x > transform.position.x && !observandoDerecha) || (player.position.x < transform.position.x && observandoDerecha))
        {
            observandoDerecha = !observandoDerecha;
            transform.eulerAngles = new Vector3(0, transform.eulerAngles.y + 180, 0);

        }
    }

    public void Ataque()
    {
        Collider2D[] objetos = Physics2D.OverlapCircleAll(controladorAtaque.position, radioAtaque);

        foreach (Collider2D objeto in objetos)
        {
            if (objeto.CompareTag("Player"))
            {
                playerLife.TakeDamage(5);

            }
        }

    }

    public void ShootPlayer(bool status)
    {
        Instantiate(knife, transform.position, Quaternion.identity).GetComponent<ArrowBehaviour>().shoot(status, 0.4f); ;
    }
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(controladorAtaque.position, radioAtaque);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {

        if (other.gameObject.tag == "Player")
        {
            //  if (otherAnimator.GetBool("Attack") == true)
            //  {
            //  life -= life * damageTaken;
            //  print(life);
            //agregar animacion de damage
            //  }

            // if (animator.GetFloat("DistanciaPlayer") <= 2)//ver como le llame  o si no agregarle uno
            // {
            //  playerLife.TakeDamage(5);
            //  }

        }


    }

    public void damageBoss(int damage)
    {
        life -= life * damageTaken;
        print(life);

        if (life <= 0)
        {
            //animacion de muerte
        }

    }
}