using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerLife : MonoBehaviour
{
    public PlayerStatusUI playerStatusUI;

    public int maxHealth { get; private set; }
    public int currentHealth { get; private set; }
    public float healthRange { get { return (float)currentHealth / (float)maxHealth; } }


    //escudo
    public int maxShield{ get; private set; }
    public int currentShield { get; private set; }
    public float shieldRange { get { return (float)currentShield / (float)maxShield; } }

    private void Start()
    {
        maxHealth = 100;
        currentHealth = maxHealth;

        maxShield = 100;
        currentShield = maxShield;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.RightAlt))//Prueba
        {
            TakeDamage(10);
            IncrementScore(1);
            

            Debug.Log(healthRange);
        }
    }

    public void TakeDamage(int damage)
    {
  
        int porciento = 2;

        if(currentShield == 0)
        {
            porciento = 1;
        }

        currentHealth -= damage/porciento;
        currentHealth = Mathf.Clamp(currentHealth, 0, maxHealth);
        currentShield -= damage;
        currentShield = Mathf.Clamp(currentShield, 0, maxShield);
        playerStatusUI.SetHealth(healthRange, shieldRange);
    }

    public void IncrementScore(int punto)
    {
        playerStatusUI.incrementScore(punto);
    }

}
