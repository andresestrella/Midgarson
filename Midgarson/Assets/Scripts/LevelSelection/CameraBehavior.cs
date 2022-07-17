using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraBehavior : MonoBehaviour
{
    public static bool slideLeft = false;
    public static bool isSliding = false;
    public float speed = 5f;
    const float MIN_X = 0f, MAX_X = 19.42f;
    public Vector3 deltaPos = new Vector3();
    public Vector3 cameraMovement = new Vector3(5,0);

    void Update()
    {
        if(slideLeft && isSliding){
            moveLeft();
        } 
        if(!slideLeft && isSliding) {
            moveRight();
        }

        transform.position = new Vector3(
            Mathf.Clamp(transform.position.x, MIN_X, MAX_X),
            transform.position.y,
            transform.position.z
        );
    }

    void moveRight(){
        transform.Translate(Vector3.right * speed * Time.deltaTime);
    }

    void moveLeft(){
        transform.Translate(Vector3.left * speed * Time.deltaTime);
    }
}
