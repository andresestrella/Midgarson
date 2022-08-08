using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SettingsInGame : MonoBehaviour
{
    public string openScene;

    void Start()
    {
        
    }

    public void OnMouseDown() {
        Time.timeScale = 0f;
        CloseBehavior.closeThisScene = SceneManager.GetActiveScene().name;
        print(CloseBehavior.closeThisScene);
        SceneManager.LoadScene(openScene, LoadSceneMode.Additive);
    }

}
