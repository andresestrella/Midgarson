using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerMovement : MonoBehaviour
{
    private float force = 0.05f;
    private bool move = false;

    void Update()
    {
        if(move){
            transform.position += Vector3.right * force;
        }        
    }

    private void OnCollisionEnter2D(Collision2D other) {
        if(other.gameObject.tag == "Player"){
            move = true;
        }

    }
}
