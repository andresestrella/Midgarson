using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CloseBehavior : MonoBehaviour
{
    public static string closeThisScene;
    void Start()
    {
        
    }

    private void OnMouseDown() {
        Time.timeScale = 1f;
        ActiveCanvas.activateCanvas = true;
        SceneManager.LoadScene(closeThisScene);
    }
}
