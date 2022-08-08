using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeavyEnemy : Enemy
{

    private void Awake()
    {
        animator = GetComponent<Animator>();
    }

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        target = GameObject.FindGameObjectWithTag("Player");
        damage = GameManagement.heavyEnemyAttack_give;
        runSpeed = GameManagement.heavyEnemyAttack_velocity;
        name = EnemyTag.HeavySoldier;
    }

    

    // Update is called once per frame
    void Update()
    {
        behavor();
    }

    


}
