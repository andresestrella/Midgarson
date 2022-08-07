using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class BotonesTienda : MonoBehaviour
{
    public TextMeshProUGUI arcoPrecio;
    public TextMeshProUGUI armaduraPrecio;
    public TextMeshProUGUI hachaPrecio;
    public TextMeshProUGUI espadaPrecio;
    public TextMeshProUGUI bolsaExplosivosPrecio;
    public TextMeshProUGUI polvoraPrecio;
    public TextMeshProUGUI flechasPrecio;
    public TextMeshProUGUI vidasPrecio;
    public TextMeshProUGUI cuchillosPrecio;

    public TextMeshProUGUI coins;

    public Button arcoButton;
    public Button armaduraButton;
    public Button hachaButton;
    public Button espadaButton;
    public Button bolsaExplosivosButton;
    public Button polvoraButton;
    public Button flechasButton;
    public Button vidasButton;
    public Button cuchillosButton;

    void Start()
    {
        
    }

    void Update()
    {
        coins.text = GameManagement.coinsEarned.ToString();
        arcoPrecio.text = GameManagement.arco_precio.ToString();
        armaduraPrecio.text = GameManagement.armadura_precio.ToString();
        hachaPrecio.text = GameManagement.hacha_precio.ToString();
        espadaPrecio.text = GameManagement.espada_precio.ToString();
        bolsaExplosivosPrecio.text = GameManagement.explosivo_precio.ToString();
        flechasPrecio.text = GameManagement.flechas_precio.ToString();
        vidasPrecio.text = GameManagement.vidas_precio.ToString();
        cuchillosPrecio.text = GameManagement.cuchillo_precio.ToString();

        if(Input.GetKeyDown("space")){
            GameManagement.coinsEarned += 1500f;
        }
    }

    //on click
    public void updateArco(){
        if(GameManagement.coinsEarned - 2300f >= 0f){
            if(GameManagement.arco_precio == 2300f && GameManagement.arco_available){
                GameManagement.coinsEarned -= 2300f;
                arcoButton.interactable = false;
                GameManagement.arco_available = false;
                GameManagement.damageLeif_givesFlecha *= 0.50f;
            }            
        } else {
            arcoButton.interactable = false;
        }
    }

    public void updateArmadura(){
        if(GameManagement.coinsEarned - 500f >= 0f){
            if(GameManagement.armadura_precio == 500f && GameManagement.armadura_available){
                GameManagement.coinsEarned -= 500f;
                armaduraButton.interactable = false;
                GameManagement.armadura_available = false;
                GameManagement.resistenciaLeif = 0.5f;
            }            
        } else {
            armaduraButton.interactable = false;
        }
    }

    public void updateHacha(){
        if(GameManagement.coinsEarned - GameManagement.hacha_precio >= 0f){
            if(GameManagement.hacha_precio == 1300f){
                GameManagement.coinsEarned -= GameManagement.hacha_precio;
                GameManagement.hacha_precio = 2300f;
                GameManagement.damageLeif_givesHacha *= 1.10f;
                return;
            }
            if(GameManagement.hacha_precio == 2300f){
                GameManagement.coinsEarned -= GameManagement.hacha_precio;
                GameManagement.hacha_precio = 3000f;
                GameManagement.damageLeif_givesHacha *= 1.10f;
                return;
            }
            if(GameManagement.hacha_precio == 3000f && GameManagement.hacha_available){
                GameManagement.coinsEarned -= GameManagement.hacha_precio;
                GameManagement.damageLeif_givesHacha *= 1.10f;
                GameManagement.hacha_available = false;
                hachaButton.interactable = false;
            }
        }
    }

    public void updateEspada(){
        if(GameManagement.coinsEarned - GameManagement.espada_precio >= 0f){
            if(GameManagement.espada_precio == 700f){
                GameManagement.coinsEarned -= GameManagement.espada_precio;
                GameManagement.espada_precio = 800f;
                GameManagement.damageLeif_givesEspada *= 1.10f;
                return;
            }
            if(GameManagement.espada_precio == 800f){
                GameManagement.coinsEarned -= GameManagement.espada_precio;
                GameManagement.espada_precio = 1500f;
                GameManagement.damageLeif_givesEspada *= 1.15f;
                return;
            }
            if(GameManagement.espada_precio == 1500f && GameManagement.espada_available){
                GameManagement.coinsEarned -= GameManagement.espada_precio;
                GameManagement.espada_available = false;
                GameManagement.damageLeif_givesEspada *= 1.20f;
                espadaButton.interactable = false;
            }
        }
    }

    public void updateBolsaExplosivo(){
        if(GameManagement.coinsEarned - 300f >= 0f && GameManagement.explosivo_available){
            GameManagement.coinsEarned -= 300f;
            GameManagement.explosivo_available = false;
            bolsaExplosivosButton.interactable = false;
            GameManagement.explosivoCantidad += 3;
        }
    }

    public void updateFlechas(){
        if(GameManagement.coinsEarned - 30f >= 0f){
            GameManagement.coinsEarned -= 30f;
            GameManagement.flechasCantidad += 10f;
        } 
    }

    public void updateVidas(){
        if(GameManagement.vidas_limit > 1f){
            if(GameManagement.coinsEarned - 300f >= 0f){
                GameManagement.coinsEarned -= 300f;
                GameManagement.vidas_limit -= 1f;
                PlayerLife.AddHealth(100);
            } 
        } else {
            GameManagement.vidas_available = false;
            vidasButton.interactable = false;
        }
    }

    public void updateCuchillos(){
        if(GameManagement.coinsEarned - 200f >= 0f){
            GameManagement.coinsEarned -= 200f;
            GameManagement.cuchilloCantidad += 10f;
        } 
    }

    //on hover
    public void hoverFlecha(){
        if((GameManagement.coinsEarned - 30f) >= 0f){
            flechasButton.interactable = true;
        } else {
            flechasButton.interactable = false;
        }
    }

    public void hoverCuchillos(){
        if((GameManagement.coinsEarned - 200f) >= 0f){
            cuchillosButton.interactable = true;
        } else {
            cuchillosButton.interactable = false;
        }
    }

    public void hoverEspada(){
        if((GameManagement.coinsEarned - GameManagement.espada_precio) >= 0f && GameManagement.espada_available){
            espadaButton.interactable = true;
        } else {
            espadaButton.interactable = false;
        }
    }

    public void hoverHacha(){
        if((GameManagement.coinsEarned - GameManagement.hacha_precio) >= 0f && GameManagement.hacha_available){
            hachaButton.interactable = true;
        } else {
            hachaButton.interactable = false;
        }
    }

    public void hoverVidas(){
        if((GameManagement.coinsEarned - GameManagement.vidas_precio) >= 0f && GameManagement.vidas_available){
            vidasButton.interactable = true;
        } else {
            vidasButton.interactable = false;
        }
    }

    public void hoverExplosivos(){
        if((GameManagement.coinsEarned - GameManagement.explosivo_precio) >= 0f && GameManagement.explosivo_available){
            bolsaExplosivosButton.interactable = true;
        } else {
            bolsaExplosivosButton.interactable = false;
        }
    }

    public void hoverArco(){
        if((GameManagement.coinsEarned - GameManagement.arco_precio) >= 0f && GameManagement.arco_available){
            arcoButton.interactable = true;
        } else {
            arcoButton.interactable = false;
        }
    }

    public void hoverArmadura(){
        if((GameManagement.coinsEarned - GameManagement.armadura_precio) >= 0f && GameManagement.armadura_available){
            armaduraButton.interactable = true;
        } else {
            armaduraButton.interactable = false;
        }
    }
}
