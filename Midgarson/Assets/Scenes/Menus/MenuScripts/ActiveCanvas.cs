using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActiveCanvas : MonoBehaviour
{
    public GameObject canvas;
    public static bool activateCanvas = true;

    void Start()
    {
        
    }

    void Update()
    {
        if(activateCanvas){
            canvas.SetActive(true);
        } else {
            canvas.SetActive(false);
        }
        
    }
}
