using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class HoverMouseBehavior : MonoBehaviour
{
    public GameObject lvlInfoWindow;
    private Dictionary<string, int> lvlInfo = new Dictionary<string, int>();
    public string level;
    public TextMeshProUGUI lvlTitle;
    public TextMeshProUGUI lvlScore;
    
    void Start()
    {
        lvlTitle.text = level;
        lvlInfo.Add(LevelInfo.lvl1Title, LevelInfo.lvl1Score);
        lvlInfo.Add(LevelInfo.lvl2Title, LevelInfo.lvl2Score);
        lvlInfo.Add(LevelInfo.lvl3Title, LevelInfo.lvl3Score);
        lvlInfo.Add(LevelInfo.lvl4Title, LevelInfo.lvl4Score);
        lvlInfo.Add(LevelInfo.lvl5Title, LevelInfo.lvl5Score);
        lvlInfo.Add(LevelInfo.lvl6Title, LevelInfo.lvl6Score);
        lvlInfoWindow.SetActive(false);
    }

    private void Update() {
        lvlScore.text = "Score: " + lvlInfo[level].ToString();
    }

    private void OnMouseExit() {
        lvlInfoWindow.SetActive(false);
    }

    private void OnMouseEnter() {
        lvlInfoWindow.SetActive(true);
    }

}
