using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelStopBehavior : MonoBehaviour
{
    private GameObject lvl1Stop;
    private GameObject lvl2Stop;
    private GameObject lvl3Stop;
    private GameObject lvl4Stop;
    private GameObject lvl5Stop;
    private GameObject lvl6Stop;
    public Material available;
    
    void Start()
    {
        lvl1Stop = GameObject.FindWithTag("lvl1Stop");
        lvl2Stop = GameObject.FindWithTag("lvl2Stop");
        lvl3Stop = GameObject.FindWithTag("lvl3Stop");
        lvl4Stop = GameObject.FindWithTag("lvl4Stop");
        lvl5Stop = GameObject.FindWithTag("lvl5Stop");
        lvl6Stop = GameObject.FindWithTag("lvl6Stop");
        List<GameObject> lvlStops = new List<GameObject>();
        lvlStops.Add(lvl1Stop);
        lvlStops.Add(lvl2Stop);
        lvlStops.Add(lvl3Stop);
        lvlStops.Add(lvl4Stop);
        lvlStops.Add(lvl5Stop);
        lvlStops.Add(lvl6Stop);
        for(int i = 0; i < LevelInfo.playerCurrentLevel; i++){
            lvlStops[i].GetComponent<SpriteRenderer>().material = available;
        }
    }
}
