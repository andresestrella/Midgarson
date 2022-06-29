using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackForthMovement : MonoBehaviour
{
    public Transform targetB;
    private Vector3 nextPos;
    public Vector3 posA;
    public Vector3 posB;
    public float speed = 2;
    SpriteRenderer renderer;
    void Start()
    {
        renderer = GetComponent<SpriteRenderer>();
        posA = transform.localPosition;
        posB = targetB.localPosition;
        nextPos = posB;
    }

    void Update()
    {
        Move();
    }

    private void Move(){
        transform.localPosition = Vector3.MoveTowards(transform.localPosition, nextPos, speed * Time.deltaTime);
        if(Vector3.Distance(transform.localPosition, nextPos) <= 0.1){
            ChangeDestination();
            renderer.flipX = !(nextPos.x > gameObject.transform.position.x);

        }
    }

    private void ChangeDestination(){
        nextPos = nextPos != posA ? posA : posB;
    }
}
