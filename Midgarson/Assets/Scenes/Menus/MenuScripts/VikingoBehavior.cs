using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class VikingoBehavior : MonoBehaviour
{
    public void OnButtonPress(){
        GameManagement.backToDefaultDifficulty();
        GameManagement.applyDifficultyEnemiesVelocity(1.10f);//10% mas
        GameManagement.applyDifficultyEnemiesDamage(1.30f);//30% mas
        SceneManager.LoadScene("Log-in"); 
    }
    
}
