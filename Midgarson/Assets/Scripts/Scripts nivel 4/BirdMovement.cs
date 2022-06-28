using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BirdMovement : MonoBehaviour
{
    Vector3 _deltaPos = new Vector3();
    Vector3 moveSpeed = new Vector3(10,0);
    private SpriteRenderer mySprite;

    private void Awake()
    {
        //myBody = GetComponent<Rigidbody2D>();
        mySprite = GetComponent<SpriteRenderer>();
        //anim = GetComponent<Animator>();
        mySprite.flipX = true;
    }
    void Start()
    {
        
    }

    void Update()
    {//se mueve hacia la izquierda
        _deltaPos.x = (float)1.0 * (- moveSpeed.x);
        _deltaPos *= Time.deltaTime;
        gameObject.transform.Translate(_deltaPos);
    }
}
