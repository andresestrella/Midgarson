using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GotoNextLevel : MonoBehaviour
{
    Dictionary <string, string> levelScenes = new Dictionary<string, string>();

    // Start is called before the first frame update
    void Start()
    {
        levelScenes.Add("Scene1","Scene2P2");
        levelScenes.Add("Scene2P2","Scene3");
        levelScenes.Add("Scene3-3","Scene4");
        levelScenes.Add("Scene4","Scene5");//5 - cuando se muera, esperar un momento y luego ir la otra escena
        levelScenes.Add("Scene5","Scene6 1");
        //levelScenes.Add("Scene6 1",""); go to credits
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter2D(Collision2D other) {
        if(other.gameObject.tag == "Player"){
            SceneManager.LoadScene(levelScenes[SceneManager.GetActiveScene().name]);
        }
    }
}
