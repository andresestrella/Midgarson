using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class LevelClearScreen : MonoBehaviour
{   
    public TextMeshPro pointsText;
    public TextMeshPro timeText;

    public void Setup(int score, float time){
        gameObject.SetActive(true);
        pointsText.text = score.ToString() + " POINTS";
        timeText.text = "TIME: " + time.ToString();
    }
}
