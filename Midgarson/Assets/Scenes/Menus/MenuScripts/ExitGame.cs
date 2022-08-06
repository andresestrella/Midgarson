using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class ExitGame : MonoBehaviour
{
    public void OnButtonPress(){
        print("presssed");
        Application.Quit(); //en build
        //EditorApplication.Exit(0); //cerrar editor
    }
}
