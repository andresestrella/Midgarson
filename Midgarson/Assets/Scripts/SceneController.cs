using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneController : MonoBehaviour
{
    public PlayerStatusUI playerStatusUI;
    public int scorePlay = 0;
    public int coins = 0;
    public GameOverScreen gameOverScreen;
    public LevelClearScreen levelClearScreen;
    public static SceneController instancia;
    private GameObject item;

    void Awake()
    {
        //instancia = new SceneController();
    }
    void Start()
    {
        GameObject[] list = Resources.LoadAll<GameObject>("Items");
        GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy");

        for (int i = 0; i < enemies.Length; i++)
        {
            int randomIndex = Random.Range(0, list.Length);
            item = list[randomIndex];
            enemies[i].GetComponent<Enemy>().item = item;
        }
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

    public void incrementCoins(int coinsValue)
    {
        coins += coinsValue;
        playerStatusUI.updateCoinsText();
    }

    public void GameOver()
    {
        gameOverScreen.Setup();
    }
    public void LevelClear()
    {
        levelClearScreen.Setup();
    }



}
