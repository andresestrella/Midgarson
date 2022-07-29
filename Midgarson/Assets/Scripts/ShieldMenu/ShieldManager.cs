using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ShieldManager : MonoBehaviour
{
    public ShieldDatabase shieldDB;
    public SpriteRenderer artworkSprite;

    private int selectedShield = 0;

    // Start is called before the first frame update
    void Start()
    {
        UpdateShield(selectedShield);
    }

    public void NextOption()
    {
        selectedShield++;

        if(selectedShield >= shieldDB.ShieldCount)
        {
            selectedShield = 0;
        }

        UpdateShield(selectedShield);
        SaveShield();
    }

    public void BackOption() 
    {
        selectedShield--;

        if(selectedShield < 0)
        {
            selectedShield = shieldDB.ShieldCount - 1;
        }

        UpdateShield(selectedShield);
        SaveShield();
    }

    private void UpdateShield(int selectedOption)
    {
        Shield shield = shieldDB.GetShield(selectedOption);
        artworkSprite.sprite = shield.shieldSprite;
    }

    private void LoadShield()
    {
        selectedShield = PlayerPrefs.GetInt("selectedShield");
    }

    private void SaveShield()
    {
        PlayerPrefs.SetInt("selectedShield", selectedShield);
    }

    public void ChangeScene(int sceneID)
    {
        SceneManager.LoadScene("Scene1");
    }
}
