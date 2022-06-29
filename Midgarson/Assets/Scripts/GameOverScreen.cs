using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverScreen : MonoBehaviour
{
    public void Setup(){
        gameObject.SetActive(true);
    }

    public void RestartButton(){
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void ExitButton(){
        //SceneManager.LoadScene("MainMenu");
    }
}
