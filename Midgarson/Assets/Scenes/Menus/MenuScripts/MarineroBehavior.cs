using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MarineroBehavior : MonoBehaviour
{
    public void OnButtonPress(){
        GameManagement.backToDefaultDifficulty();
        SceneManager.LoadScene("Log-in"); 
    }
    
}
