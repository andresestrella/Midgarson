using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneController : MonoBehaviour
{
    public PlayerStatusUI playerStatusUI;
    public int scorePlay = 0;
    public GameOverScreen gameOverScreen;
    public LevelClearScreen levelClearScreen;
    public static SceneController instancia;
    
    void Awake(){
        //instancia = new SceneController();
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void IncrementScore(int punto)
    {
        scorePlay += punto;
        playerStatusUI.updateScoreText();
    }

    public void loadScores(int puntos)
    {
        scorePlay = puntos;
        playerStatusUI.updateScoreText();
    }

    public void GameOver(){
        gameOverScreen.Setup();
    }
    public void LevelClear(){
        levelClearScreen.Setup();
    }

    

}
