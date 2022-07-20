using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrowBehaviour : MonoBehaviour
{
    float shootingTime, flyingSpeed;
    int damage = 5;
    Vector2 pos;

    public PlayerLife playerLife;

    private void Awake()
    {
        playerLife = GameObject.Find("Player1").GetComponent<PlayerLife>();
    }

    public void shoot(bool flip, float velocity)
    {
        shootingTime = Time.time;
        if (flip)
        {
            transform.Rotate(0f, 180f, 0);
        }

        flyingSpeed = velocity;

    }

    void Update()
    {
        pos.x = pos.x + flyingSpeed * Time.deltaTime/2;

        gameObject.transform.Translate(pos);
        if(Time.time - shootingTime > 5)
        {
            Destroy(gameObject);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag != "Player")
        {
            collision.gameObject.GetComponent<Enemy>().takeDamage(damage);
            Destroy(gameObject);
        }

        if (collision.gameObject.tag == "Player")
        {
            playerLife.TakeDamage(5);
            Destroy(gameObject);
        }
    }
}
