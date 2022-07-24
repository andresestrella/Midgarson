using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NextScene : MonoBehaviour
{
    public string nextScene;

    private void OnCollisionEnter2D(Collision2D other) {
        if(other.gameObject.tag == "Player"){
            SceneManager.LoadScene(nextScene);
        }

    }

    
    /*void OnTriggerEnter(Collider other) {
        if(other.gameObject.tag == "enemy"){
            print("hit!");
        }
    }*/
}
