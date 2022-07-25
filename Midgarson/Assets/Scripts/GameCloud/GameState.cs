using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameState
{
    public long? id
    {
        get { return id; }
        set { id = value; }
    }
    public long userId;
    public int level;

    public string dificulty;
    public int playerHealth;
    public int playerShield;
    public int money;
    public string inventory;
    public float currPosX;
    public float currPosY;
    public int score;

    public GameState(long userId,int level,string dificulty, int playerHealth,int playerShield, int money,string inventory, float currPosX,float currPosY,int score)
    {
        this.userId = userId;
        this.level = level;
        this.dificulty = dificulty;
        this.playerHealth = playerHealth;
        this.playerShield = playerShield;
        this.money = money;
        this.inventory = inventory;
        this.currPosX = currPosX;
        this.currPosY = currPosY;
        this.score = score;
    }

}
