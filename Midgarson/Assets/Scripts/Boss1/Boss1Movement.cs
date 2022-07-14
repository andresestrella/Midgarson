using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss1Movement : MonoBehaviour
{
    public Transform player;
    //public GameObject otherObject;
    public Animator otherAnimator;
    public PlayerLife playerLife;
    
    public Rigidbody2D rb;
    public double life = 100;
    public double damageTaken = 0.9;
    public float moveSpeed = 2f;

    public float chrono;
    public int rutine;

    public Animator anim;

    public float simpleAttackRange = 9f;
    /*public float dashRange = 16f; NO BORRAR
    public int dashSpeed = 5;
    private float dashTime;
    public float startDashTime = 0.1f;
    private int direction;
    private bool isDashing = true;

    private Vector2 velocity = new Vector2();*/

    void Awake () {
        //otherAnimator = otherObject.GetComponent<Animator>();
    }
    private void Start() {
        rb = gameObject.GetComponent<Rigidbody2D>();
        //dashTime = startDashTime;
    }

    private void Update() {
        if(anim.GetBool("isDead") == false){
            followPlayer();
            simpleAttack();
        }

        chrono += 1 * Time.deltaTime;
        if (chrono >= Random.Range(1,4))
        {
            rutine = Random.Range(0, 3);
            chrono = 0;
        }

        if(rutine <= 1){
            anim.SetBool("isWalking", false);
            moveSpeed *= 0;
        }
        if(rutine > 1){
            anim.SetBool("isWalking", true);
            moveSpeed = 2;
        }
        
        
        /*if(Input.GetButtonDown("Fire1")){NO BORRAR
            float inicialTime = Time.time;
            while (Time.time < inicialTime + 2)
            {
                print("dash");
                transform.Translate(Vector3.right * dashSpeed * Time.deltaTime);
            }
        }*/

        if(life <= 1){
            anim.SetBool("isWalking", false);
            anim.SetBool("isDead", true);

            GameObject.Find("TimelineManager").GetComponent<TimelineController>().Play();
            life = 2; //para que no se active el cutscene cada frame despues de que muere el boss
        }
        /*if(Input.GetButtonDown("Fire1")){
            life -= life * damageTaken;
            print(life);
        }*/
    }

    private void simpleAttack(){
        if( (transform.position - player.transform.position).sqrMagnitude < simpleAttackRange )
        {
            anim.SetBool("isAttacking", true);
        } else {
            anim.SetBool("isAttacking", false);
        }
    }

    private void followPlayer(){
        //anim.SetBool("isWalking", true);
        if (transform.position.x < player.transform.position.x)
        {            
            transform.Translate(Vector3.right * moveSpeed * Time.deltaTime);
            transform.rotation = Quaternion.Euler(0, 0, 0);
        }
        else
        {
            transform.Translate(Vector3.right * moveSpeed * Time.deltaTime);
            transform.rotation = Quaternion.Euler(0, 180, 0);
        }
    }

    private void OnTriggerEnter2D(Collider2D other) {
        if(other.gameObject.tag == "Player" && anim.GetBool("isDead") == false){           
            if(otherAnimator.GetBool("Attack") == true){
                life -= life * damageTaken;
                print(life);
                //agregar animacion de damage
            }
            if(anim.GetBool("isAttacking") == true){
                playerLife.TakeDamage(5);
            } /*else{
                //PlayerLife.TakeDamage(10);
                print("Take damage -10");
            }*/
        }
    }
}