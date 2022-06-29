using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RockMovement : MonoBehaviour
{
    Vector3 _deltaPos = new Vector3();
    Vector3 moveSpeed = new Vector3(10,10);
    private SpriteRenderer mySprite;
    private bool falling = false;

    private void Awake()
    {
        mySprite = GetComponent<SpriteRenderer>(); 
    }

    void Update()
    {
        //si esta en la misma coordenada X que el jugador, empieza a caer
        if(transform.position.x == GameObject.Find("Player1").transform.position.x){
            falling = true;
        }
        if(falling == true){
            transform.Rotate (Vector3.forward * -1);
            MoveDown();
        }else{
            MoveLeft();
        }
        
    }

    private void OnTriggerEnter(Collider other){
        //si other tiene script de player, llamar a la funcion de hacerle danio
        if (other.GetComponent<PlayerMovement>() != null){
            //other.GetComponent<PlayerMovement>().dealDmg();
            Destroy(gameObject);
        }else{
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

    IEnumerator RotateMe(Vector3 byAngles, float inTime)
    {
        var fromAngle = transform.rotation;
        var toAngle = Quaternion.Euler(transform.eulerAngles + byAngles);
        for (var t = 0f; t < 1; t += Time.deltaTime / inTime)
        {
            transform.rotation = Quaternion.Slerp(fromAngle, toAngle, t);
            yield return null;
        }
    }
}
