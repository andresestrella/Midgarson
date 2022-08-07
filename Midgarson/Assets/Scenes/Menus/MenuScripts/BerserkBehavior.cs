using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BerserkBehavior : MonoBehaviour
{
    public void OnButtonPress(){
        GameManagement.backToDefaultDifficulty();
        GameManagement.applyDifficultyLeifDamage_Give(0.20f);//20% menos
        GameManagement.applyDifficultyEnemiesDamage(1.60f);//60% mas
        GameManagement.applyDifficultyDrops(0.50f);//50% menos
        SceneManager.LoadScene("Log-in"); 
    }
    
}
