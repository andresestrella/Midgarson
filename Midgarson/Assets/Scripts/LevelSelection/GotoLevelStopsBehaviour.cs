using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GotoLevelStopsBehaviour : MonoBehaviour
{
    //public Material available;
    private Dictionary<string, string> levels = new Dictionary<string, string>();
    public GameObject lvlStop;

    void Start()
    {
        levels.Add("level1Stop", "Scene1");
        levels.Add("level2Stop", "Scene2P2");
        levels.Add("level3Stop", "Scene3");
        levels.Add("level4Stop", "Scene4");
        levels.Add("level5Stop", "Scene5 1");
        levels.Add("level6Stop", "Scene6 1");
    }

    private void OnMouseDown() {
        if(lvlStop.GetComponent<SpriteRenderer>().material.name == "Blue (Instance)"){
            SceneManager.LoadScene(levels[lvlStop.name]);
        }
    }
}
