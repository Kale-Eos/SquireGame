using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class MenuMusicManager : MonoBehaviour
{

    public AudioMixer audioMixer;
    public string SoundFile;

    //cache
    private AudioManager audioManager;

    public void Start()
    {
        audioManager = AudioManager.instance;
        if (audioManager == null)
        {
            Debug.Log("No AudioManager found.");
        }
        audioManager.PlaySound(SoundFile);
    }

    public void SetVolume(float volume)
    {
        audioMixer.SetFloat("Volume", volume);
    }
}