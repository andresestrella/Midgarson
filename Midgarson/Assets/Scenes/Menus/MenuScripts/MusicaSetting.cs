using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MusicaSetting : MonoBehaviour
{
    Toggle music_Toggle;

    void Start()
    {
        music_Toggle = GameObject.Find("MusicaSetting").GetComponent<Toggle>();
        music_Toggle.onValueChanged.AddListener(delegate {
            OnPointerClick();
        });
        music_Toggle.isOn = GameManagement.music_ON;
    }

    public void OnPointerClick(){
        GameManagement.music_ON = music_Toggle.isOn;
        print("music: " + GameManagement.music_ON);
    }
}
