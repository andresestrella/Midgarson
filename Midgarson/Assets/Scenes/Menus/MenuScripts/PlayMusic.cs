using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayMusic : MonoBehaviour
{
    AudioSource music_audio;
    bool isPlaying = true;

    void Start()
    {
        music_audio = gameObject.GetComponent<AudioSource>();
    }

    void Update()
    {
        if(isPlaying){
            if(GameManagement.music_ON){
                music_audio.Play();
                isPlaying = false;
            }
        }
        
        if(!GameManagement.music_ON){
            music_audio.Stop();
            isPlaying = true;
        }
        
    }
}
