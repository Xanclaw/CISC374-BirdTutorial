using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public AudioSource backgroundMusic;
    public AudioClip backgroundMusicClip;

    void Start()
    {
        
        if (backgroundMusic != null && backgroundMusicClip != null)
        {
            backgroundMusic.clip = backgroundMusicClip;
            backgroundMusic.loop = true;
            backgroundMusic.Play(); 
        }
    }
}

