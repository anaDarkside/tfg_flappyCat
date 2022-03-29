using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class AudioManager : MonoBehaviour
{
    public AudioMixer musicMixer;
    public AudioSource backgroundMusic;
    public static AudioManager instance;
    public float masterVol;

    private void Awake() {
        if (instance == null) {
            instance = this;
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        PlayAudio(backgroundMusic);
    }

    // Update is called once per frame
    void Update()
    {
        MasterVolume();
    }

    public void MasterVolume(){
        musicMixer.SetFloat("MasterVolume", masterVol);
    }
    
    public void PlayAudio(AudioSource audio) {
        audio.Play();
    }
}
