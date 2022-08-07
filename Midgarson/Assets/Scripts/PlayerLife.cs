using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerLife : MonoBehaviour
{
    private Animator anim;

    public SceneController sceneController;
    public PlayerStatusUI playerStatusUI;
    private string DYING_ANIMATION = "isDead";

    public int maxHealth { get; private set; }
    public int currentHealth { get; private set; }
    public float healthRange { get { return (float)currentHealth / (float)maxHealth; } }


    //escudo
    public int maxShield{ get; private set; }
    public int currentShield { get; private set; }
    public float shieldRange { get { return (float)currentShield / (float)maxShield; } }

    private void Start()
    {
        anim = GetComponent<Animator>();

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
            sceneController.IncrementScore(1);
            //SceneController.instancia.IncrementScore(1);
            //Debug.Log(healthRange);
        }
    }

    public void TakeDamage(int damage)
    {
        if(currentShield <= 0)
        {
            currentHealth -= damage;
            currentHealth = Mathf.Clamp(currentHealth, 0, maxHealth);
        }
        else
        {
            currentShield -= damage * GameManagement.resistenciaLeif;
            currentShield = Mathf.Clamp(currentShield, 0, maxShield);
        }

        playerStatusUI.SetHealth(healthRange, shieldRange);
<<<<<<< Updated upstream

        if (currentHealth <= 0) {
            gameObject.GetComponent<PlayerMovement>().enabled = false;
            anim.SetBool(DYING_ANIMATION, true);

=======
        if (currentHealth <= 0) {
            gameObject.GetComponent<PlayerMovement>().enabled = false;
            anim.SetBool(DYING_ANIMATION, true);
>>>>>>> Stashed changes
        }
    }

    public void setLoadedStatus(int health, int shield,int score,float time)
    {
        currentHealth = health;
        currentShield = shield;
        sceneController.loadScores(score);
        playerStatusUI.SetHealth(healthRange, shieldRange);
        playerStatusUI.setplaytime(time);
        if (currentHealth <= 0)
        {
            gameObject.GetComponent<PlayerMovement>().enabled = false;
            anim.SetBool(DYING_ANIMATION, true);
        }
    }

    public void _gameOver()
    {
        anim.SetBool("auxDead", false);
        sceneController.GameOver();
    }

    public void AddHealth(int health)
    {
        if (!((currentHealth+health) > 100))
        {
            currentHealth += health;
            playerStatusUI.SetHealth(healthRange, shieldRange);
        }
        else
        {
            currentHealth = 100;
            playerStatusUI.SetHealth(healthRange, shieldRange);
        }
    }

    public void AddShield(int shield)
    {
        if (!((currentShield + shield) > 100))
        {
            currentShield += shield;
            playerStatusUI.SetHealth(healthRange, shieldRange);
        }
        else
        {
            currentShield = 100;
            playerStatusUI.SetHealth(healthRange, shieldRange);
        }
    }


}
