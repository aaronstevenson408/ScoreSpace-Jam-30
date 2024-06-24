using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class SoundManager : MonoBehaviour
{
    public static SoundManager instance;
    public AudioSource Music;
    public AudioSource SFX;
    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }
    private void Update()
    {
        DontDestroyOnLoad(gameObject);
    }
    public void ChangeMusic(AudioClip clip)
    {
        Music.Stop();
        Music.loop = true;
        Music.PlayOneShot(clip);
    }
    public void ChangeSFX(AudioClip clip)
    {
        SFX.PlayOneShot(clip);
    }
    public void SFXVolume(float value)
    {
        SFX.volume = value / 100;
    }
    public void MusicVolume(float value)
    {

        Music.volume = value / 100;
    }
}
