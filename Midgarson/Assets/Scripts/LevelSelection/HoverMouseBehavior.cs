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
        lvlInfo.Add(GameManagement.lvl1Title, PlayerPrefs.GetInt("L1"));
        lvlInfo.Add(GameManagement.lvl2Title, PlayerPrefs.GetInt("L2"));
        lvlInfo.Add(GameManagement.lvl3Title, PlayerPrefs.GetInt("L3"));
        lvlInfo.Add(GameManagement.lvl4Title, PlayerPrefs.GetInt("L4"));
        lvlInfo.Add(GameManagement.lvl5Title, PlayerPrefs.GetInt("L5"));
        lvlInfo.Add(GameManagement.lvl6Title, PlayerPrefs.GetInt("L6"));
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
