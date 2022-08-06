using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class AjustesBehavior : MonoBehaviour
{
    public void OnButtonPress(){
        SceneManager.LoadScene("Ajustes");
    }
    
}
