using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class AjustesInGame : MonoBehaviour
{
    public void OnButtonPress(){
        CloseBehavior.closeThisScene = SceneManager.GetActiveScene().name;
        SceneManager.LoadScene("AjustesInGame", LoadSceneMode.Additive);
    }

}
