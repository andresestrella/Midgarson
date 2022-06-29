using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class LevelClearScreen : MonoBehaviour
{   
    public TextMeshProUGUI pointsText;
    public TextMeshProUGUI timeText;
    public SceneController sceneController;

    public void Setup(){
        gameObject.SetActive(true);
        pointsText.text = sceneController.scorePlay.ToString() + " POINTS";
        timeText.text = "TIME: " + Time.time.ToString();
    }

    public void ExitButton(){
        //SceneManager.LoadScene("MainMenu");
    }
    public void ContinueButton(){
        //SceneManager.LoadScene("LevelSelectMenu");
    }
}
