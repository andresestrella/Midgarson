using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelStopBehavior : MonoBehaviour
{
    public int currentLevelPlayer;
    List<string> levelStopsTags = new List<string>();
    public Material available; //colored blue
    //public Material blocked;   //colored red

    void Start()
    {
        currentLevelPlayer = 1;
        
        levelStopsTags.Add("lvl1Stop");
        levelStopsTags.Add("lvl2Stop");
        levelStopsTags.Add("lvl3Stop");
        levelStopsTags.Add("lvl4Stop");
        levelStopsTags.Add("lvl5Stop");
        levelStopsTags.Add("lvl6Stop");

        for(int i = 0; i < currentLevelPlayer; i++){
            GameObject levelStop = GameObject.FindGameObjectWithTag(levelStopsTags[i]);
            levelStop.GetComponent<SpriteRenderer>().material = available;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
