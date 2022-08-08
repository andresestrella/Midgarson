using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicEnemy : Enemy
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
        damage = GameManagement.basicEnemyAttack_give;
        runSpeed = GameManagement.basicEnemyAttack_velocity;
        name = EnemyTag.Basic;
    }

    

    // Update is called once per frame
    void Update()
    {
        behavor();
    }

    


}
