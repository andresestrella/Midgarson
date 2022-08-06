using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FXSetting : MonoBehaviour
{
    Toggle FX_Toggle;

    void Start()
    {
        FX_Toggle = GameObject.Find("FXSetting").GetComponent<Toggle>();
        FX_Toggle.onValueChanged.AddListener(delegate {
            OnPointerClick();
        });
        FX_Toggle.isOn = GameManagement.fx_ON;
    }

    public void OnPointerClick(){
        GameManagement.fx_ON = FX_Toggle.isOn;
        print("fx: " + GameManagement.fx_ON);
    }
}
