using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class LevelClearScreen : MonoBehaviour
{   
    public TextMeshProUGUI pointsText;
    public TextMeshProUGUI timeText;

    public void Setup(){
        gameObject.SetActive(true);
        //pointsText.text = score.ToString() + " POINTS";
        //timeText.text = "TIME: " + time.ToString();
    }
}
