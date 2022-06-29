using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneController : MonoBehaviour
{
    public GameOverScreen gameOverScreen;
    public LevelClearScreen levelClearScreen;
    public static SceneController instancia;
    void Start()
    {
        instancia = new SceneController();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void GameOver(){
        gameOverScreen.Setup();
    }
    public void LevelClear(){
        levelClearScreen.Setup();
    }
}
