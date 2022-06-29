using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RockMovement : MonoBehaviour
{
    Vector3 _deltaPos = new Vector3();
    Vector3 moveSpeed = new Vector3(4,4,0);
    private SpriteRenderer mySprite;
    private bool falling = false;
    public GameObject player;
    private float player_position;

    private void Awake()
    {
        mySprite = GetComponent<SpriteRenderer>(); 
        player_position = GameObject.Find("Player 1").transform.position.x;
    }

    void Update()
    {
        //si esta en la misma coordenada X que el jugador, empieza a caer
        player_position = GameObject.Find("Player 1").transform.position.x;

        if(transform.position.x - player_position <= 0.1){
            falling = true;
            transform.parent = null;
        }
        if(falling == true){
            //transform.Rotate (Vector3.forward * -1);
            MoveDown();
        }else{
            MoveLeft();
        }

    }

    private void OnCollisionEnter2D(Collision2D other){
        
        if (other.gameObject.tag == "Player"){
            //other.GetComponent<PlayerMovement>().dealDmg();
            Destroy(gameObject);
        }else if (other.gameObject.tag == "Ground"){
            Destroy(gameObject);
        }
        
    }

    void MoveLeft(){
        _deltaPos.x = (float)1.0 * (- moveSpeed.x);
        _deltaPos *= Time.deltaTime;
        gameObject.transform.Translate(_deltaPos);
    }
    void MoveDown(){
        _deltaPos.y = (float)1.0 * (- moveSpeed.y);
        _deltaPos *= Time.deltaTime;
        gameObject.transform.Translate(_deltaPos);
    }

    //MEJOR HACER ESTO CON ANIMACION
    // IEnumerator RotateMe(Vector3 byAngles, float inTime)
    // {
    //     var fromAngle = transform.rotation;
    //     var toAngle = Quaternion.Euler(transform.eulerAngles + byAngles);
    //     for (var t = 0f; t < 1; t += Time.deltaTime / inTime)
    //     {
    //         transform.rotation = Quaternion.Slerp(fromAngle, toAngle, t);
    //         yield return null;
    //     }
    // }
}
