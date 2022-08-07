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
        lvlInfo.Add(GameManagement.lvl1Title, GameManagement.lvl1Score);
        lvlInfo.Add(GameManagement.lvl2Title, GameManagement.lvl2Score);
        lvlInfo.Add(GameManagement.lvl3Title, GameManagement.lvl3Score);
        lvlInfo.Add(GameManagement.lvl4Title, GameManagement.lvl4Score);
        lvlInfo.Add(GameManagement.lvl5Title, GameManagement.lvl5Score);
        lvlInfo.Add(GameManagement.lvl6Title, GameManagement.lvl6Score);
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
