using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NivelInGame : MonoBehaviour
{
    public void OnButtonPress(){
        ActiveCanvas.activateCanvas = false;
        CloseBehavior.closeThisScene = SceneManager.GetActiveScene().name;
        SceneManager.LoadScene("SelectLevelInGame", LoadSceneMode.Additive);
    }
}
