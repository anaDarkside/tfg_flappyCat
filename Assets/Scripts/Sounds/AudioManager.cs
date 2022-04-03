using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;
using System;

public class AudioManager : MonoBehaviour
{
    public AudioMixer musicMixer;
    public AudioSource backgroundMusic;
    [Range (-80,0)] public float masterVol;
    public Slider volumeSlider;

    private static AudioMixer staticMusicMixer;
    private static AudioSource staticBackgroundMusic;

    public void PlayAudio(AudioSource audio) 
    {
        audio.Play();
    }

    // Start is called before the first frame update
    void Start()
    {
        if (staticMusicMixer == null)
        {
            staticMusicMixer = musicMixer;
            staticBackgroundMusic = backgroundMusic;
            PlayAudio(staticBackgroundMusic);
            volumeSlider.value = (float)Math.Pow(10.0f, masterVol/20.0f);
            DontDestroyOnLoad(this.gameObject);
        } else 
        {
            staticMusicMixer.GetFloat("MasterVolume", out masterVol);
            volumeSlider.value = (float)Math.Pow(10.0f, masterVol/20.0f);
        }
    }

    public void MasterVolume()
    {
        staticMusicMixer.SetFloat("MasterVolume", (float)Math.Log10(volumeSlider.value)*20.0f);
    }

}