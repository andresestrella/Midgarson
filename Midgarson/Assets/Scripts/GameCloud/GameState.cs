using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameState
{
    private long id
    {
        get { return id; }
        set { id = value; }
    }
    private long userId
    {
        get { return userId; }
        set { userId = value; }
    }
    private int level
    {
        get { return level; }
        set { level = value; }
    }
    private int playerHealth
    {
        get { return playerHealth; }
        set { playerHealth = value; }
    }
    private int money
    {
        get { return money; }
        set { money = value; }
    }
    private string inventory
    {
        get { return inventory; }
        set { inventory = value; }
    }
    private int currPosX
    {
        get { return currPosX; }
        set { currPosX = value; }
    }
    private int currPosY
    {
        get { return currPosY; }
        set { currPosY = value; }
    }

}
