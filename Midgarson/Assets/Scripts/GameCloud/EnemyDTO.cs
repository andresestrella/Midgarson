using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDTO 
{
    public long id;
    public EnemyTag name;
    public int damage;
    public float direction;
    public float life;
    public bool isDead = false;
    public float currPosX;
    public float currPosY;

    public EnemyDTO(EnemyTag name,int damage, float direction, float life, bool isDead)
    { 

        this.name = name;
        this.damage = damage;
        this.life = life;
        this.isDead = isDead;
        
    }
}
