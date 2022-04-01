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

    // Start is called before the first frame update
    void Start()
    {
        PlayAudio(backgroundMusic);
        volumeSlider.value = (float)Math.Pow(10.0f, masterVol/20.0f);
        //volumeSlider.value = (masterVol + 80)/90.0f; //TODO: cambiar formula
    }

    // Update is called once per frame
    void Update()
    {
       // MasterVolume(); //TODO: llamar desde un onChange()
    }

    public void MasterVolume()
    {
        musicMixer.SetFloat("MasterVolume", (float)Math.Log10(volumeSlider.value)*20.0f); 
        //musicMixer.SetFloat("MasterVolume", -80+volumeSlider.value*90); //TO DO: buscar formula correcta
    }
    
    public void PlayAudio(AudioSource audio) 
    {
        audio.Play();
    }
}
