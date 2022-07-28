using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class PlayerStatusUI : MonoBehaviour
{
    public SceneController sceneController;

    public TextMeshProUGUI vida, shield, score, time, coins;
    [Range(0, 5)]
    [SerializeField] private float barSpeed = 1f;
    [SerializeField] private Image healtBar, shieldBar;
    [SerializeField] private Image healtBarShadow, shieldBarShadow;

    private float nextHealth, nextShield;
    public float timePlay = 0.0f;

    private bool activeShadowHealth = false, activeShadowShield = false;

    private void Awake()
    {

        healtBar.fillAmount = 1f;
        healtBarShadow.fillAmount = healtBar.fillAmount;
        nextHealth = healtBar.fillAmount;

        //escudo
        shieldBar.fillAmount = 1f;
        shieldBarShadow.fillAmount = shieldBar.fillAmount;
        nextShield = shieldBar.fillAmount;
    }

    private void Update()
    {

        time.text = "TIME: " + formatearTiempo();


        if (healtBar.fillAmount != nextHealth)
        {
            healtBar.fillAmount = Mathf.MoveTowards(healtBar.fillAmount, nextHealth, Time.deltaTime * barSpeed);
            vida.text = (healtBar.fillAmount * 100).ToString() + "%";
        }

        if (activeShadowHealth)
        {
            healtBarShadow.fillAmount = Mathf.MoveTowards(healtBarShadow.fillAmount, nextHealth, Time.deltaTime * barSpeed * 1.7f);
            vida.text = (healtBar.fillAmount * 100).ToString() + "%";
        }
        if (healtBarShadow.fillAmount == nextHealth) activeShadowHealth = false;

        //escudo
        if (shieldBar.fillAmount != nextShield)
        {
            shieldBar.fillAmount = Mathf.MoveTowards(shieldBar.fillAmount, nextShield, Time.deltaTime * barSpeed);
            shield.text = (shieldBar.fillAmount * 100).ToString() + "%";
        }

        if (activeShadowShield)
        {
            shieldBarShadow.fillAmount = Mathf.MoveTowards(shieldBarShadow.fillAmount, nextShield, Time.deltaTime * barSpeed * 1.7f);
            shield.text = (shieldBar.fillAmount * 100).ToString() + "%";
        }
        if (shieldBarShadow.fillAmount == nextShield) activeShadowShield = false;
    }

    IEnumerator ActiveShadowHealth()
    {
        yield return new WaitForSeconds(0.2f);
        activeShadowShield = true;
        activeShadowHealth = true;
    }

    public void SetHealth(float healthPercentage, float shieldhPercentage)
    {
        nextHealth = healthPercentage;
        nextShield = shieldhPercentage;
        StartCoroutine(ActiveShadowHealth());

    }

    public void updateScoreText()
    {
        //score.text = "SCORE: " + SceneController.instancia.scorePlay.ToString();
        score.text = "SCORE: " + sceneController.scorePlay.ToString();
    }

    public void updateCoinsText()
    {
        //score.text = "SCORE: " + SceneController.instancia.scorePlay.ToString();
        coins.text = "COINS: " + sceneController.coins.ToString();
    }

    public string formatearTiempo()
    {

        if (true)//controlar el tiempo cuando el jugador esta en stop
        {
            timePlay += Time.deltaTime;
        }

        string minutos = Mathf.Floor(timePlay / 60).ToString("00");
        string segundos = Mathf.Floor(timePlay % 60).ToString("00");

        return minutos + ":" + segundos;

    }

    public void setplaytime(float time)
    {
        timePlay = time;
    }

}
