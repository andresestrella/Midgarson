using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwordmanEnemy : Enemy
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
        damage = GameManagement.swordmanEnemyAttack_give;
        runSpeed = GameManagement.swordmanEnemyAttack_velocity;
        name = EnemyTag.Swordsman;
        playerLife = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerLife>();

    }

    // Update is called once per frame
    void Update()
    {
       behavor();
    }



}
