using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StairsCollider : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        GameObject player = other.gameObject;
        player.GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezePositionX;
        //player.GetComponent<Animator>().SetBool("Fall", false);
    }
}
