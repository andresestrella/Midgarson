using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CreditosBehavior : MonoBehaviour
{
    public void OnButtonPress(){
        SceneManager.LoadScene("Credits");
    }
    
}
