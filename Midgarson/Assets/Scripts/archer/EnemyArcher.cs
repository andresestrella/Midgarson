using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyArcher : Enemy
{
    public GameObject arrow;
    public float timeToshoot, countDown;
    public double damageTaken = 0.9;
    public Animator anim;
    public Animator otherAnimator;
    float distanciaPlayer;

    public Transform player;
    public bool observandoDerecha = true;
    void Start()
    {
        player = GameObject.Find("Player 1").GetComponent<Transform>();
        countDown = timeToshoot;
        name = EnemyTag.Archery;
    }

    // Update is called once per frame
    void Update()
    {
        if (isDead)
        {
            gameObject.GetComponent<Rigidbody2D>().simulated = false;
        }
        else
        {
            distanciaPlayer = Vector2.Distance(transform.position, player.position);
            if (distanciaPlayer < 30)
            {
                countDown -= Time.deltaTime;
                if (countDown < 0)
                {
                    ShootPlayer();
                    countDown = timeToshoot;
                }

                MirarPlayer();

            }
        }


    }

    public void ShootPlayer()
    {
        GameObject spell = Instantiate(arrow,transform.position, Quaternion.identity);
    }

    public void MirarPlayer()
    {
        if ((player.position.x < transform.position.x && !observandoDerecha))
        {
            observandoDerecha = !observandoDerecha;
            transform.eulerAngles = new Vector3(0, transform.eulerAngles.y + 180, 0);
           

        }
        if ((player.position.x > transform.position.x && observandoDerecha))
        {
            observandoDerecha = !observandoDerecha;
            transform.eulerAngles = new Vector3(0, transform.eulerAngles.y + 180, 0);
            arrow.GetComponent<Transform>().eulerAngles = new Vector3(0, 180, 0);
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
       // if (other.gameObject.tag == "Player" && anim.GetBool("isDead") == false)
        //{
           // if (otherAnimator.GetBool("Attack") == true)
           // {
               // life -= life * damageTaken;
              //  print(life);
                //agregar animacion de damage
          //  }
       // }
           
        
    }
}
