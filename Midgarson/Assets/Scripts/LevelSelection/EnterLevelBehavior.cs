using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

//NOTE: the other scenes must be built ("Scene In Build" from File > Build Settings)

public class EnterLevelBehavior : MonoBehaviour
{
    Dictionary <string, string> levelScenes = new Dictionary<string, string>();
    
    void Start()
    {
        levelScenes.Add("level1Stop","Scene1");
        levelScenes.Add("level2Stop","Scene2P2");
        levelScenes.Add("level3Stop","Scene3");
        levelScenes.Add("level4Stop","Scene4");
        levelScenes.Add("level5Stop","Scene5");
        levelScenes.Add("level6Stop","Scene6 1");
    }

    private void OnMouseDown(){
        if(gameObject.GetComponent<SpriteRenderer>().material.name == "Blue (Instance)"){
            SceneManager.LoadScene(levelScenes[gameObject.name]);
        }
    }

}
