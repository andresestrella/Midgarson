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
        damage = 7;
        name = "Swordman";

    }

    // Update is called once per frame
    void Update()
    {
       behavor();
    }



}
