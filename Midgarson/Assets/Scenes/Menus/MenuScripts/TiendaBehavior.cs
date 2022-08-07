using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TiendaBehavior : MonoBehaviour
{
    public void OnButtonPress(){
        ActiveCanvas.activateCanvas = false;
        CloseBehavior.closeThisScene = SceneManager.GetActiveScene().name;
        SceneManager.LoadScene("Tienda", LoadSceneMode.Additive);
    }
}
