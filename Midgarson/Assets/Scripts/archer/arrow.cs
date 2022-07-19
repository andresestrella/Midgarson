using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class arrow : MonoBehaviour
{
    float movSpeed;
    Rigidbody2D rb;
    Vector2 moveDirection;
    public Transform player;
    void Start()
    {
        movSpeed = 5;//cambiar
        rb = GetComponent<Rigidbody2D>();
        player = GameObject.Find("Player1").GetComponent<Transform>();
        if ((player.position.x < transform.position.x ))
        {
            transform.eulerAngles = new Vector3(0, transform.eulerAngles.y + 180, 0);
        }
        moveDirection = (player.position - transform.position).normalized * movSpeed;
        rb.velocity = new Vector2(moveDirection.x, moveDirection.y);

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnBecameInvisible()
    {
        Destroy(gameObject);
    }
}
