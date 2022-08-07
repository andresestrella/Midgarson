using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CampesinoBehavior : MonoBehaviour
{
    public void OnButtonPress(){
        GameManagement.backToDefaultDifficulty();
        GameManagement.applyDifficultyLeifDamage_Give(1.10f);//10% mas
        GameManagement.applyDifficultyLeifDamage_Receives(1.15f);//15% mas
        GameManagement.applyDifficultyDrops(1.10f);//10% mas
        SceneManager.LoadScene("Log-in"); 
    }
    
}
