using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttachPlayer : MonoBehaviour
{
    public GameObject Player;
    void Start()
    {
        
    }

    private void OnTriggerEnter(Collider other){
        if (other.gameObject == Player){
            Player.transform.parent = transform;
        }
    }

    void Update()
    {
        
    }

    private void OnTriggerExit(Collider other){
        if (other.gameObject == Player){
            Player.transform.parent = null;
        }
    }
}
