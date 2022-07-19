using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrowsMovement : MonoBehaviour
{
    public bool movingRight;

    void Update()
    {
       
    }

    private void OnMouseDown() {
        if(movingRight){
            CameraMovement.direction = 1;
        } else{
            CameraMovement.direction = -1;
        }
    }
}
