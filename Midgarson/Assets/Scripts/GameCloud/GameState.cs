using System;
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
    public int currLevel;

    public string dificulty;
    public int playerHealth;
    public int playerShield;
    public int money;
    public string inventory;
    public float currPosX;
    public float currPosY;
    public int score;
    public Enemy[] enemies;
    public float time;
    public bool isFirstTime;

    public Item item1;
    public Item item2;
    public Item item3;
    public Item item4;

    public int scoreL1;
    public int scoreL2;
    public int scoreL3;
    public int scoreL4;
    public int scoreL5;
    public int scoreL6;


    public GameState(long userId, int level, string dificulty, int playerHealth,
        int playerShield, int money, string inventory, float currPosX, float currPosY,
        int score, Enemy[] enemies,float time,Item item1,Item item2,Item item3, Item item4)
    {
        this.userId = userId;
        this.currLevel = level;
        this.dificulty = dificulty;
        this.playerHealth = playerHealth;
        this.playerShield = playerShield;
        this.money = money;
        this.inventory = inventory;
        this.currPosX = currPosX;
        this.currPosY = currPosY;
        this.score = score;
        this.enemies = enemies;
        this.time = time;

        this.item1 = item1;
        this.item2 = item2;
        this.item3 = item3;
        this.item4 = item4;
    
    }

}
