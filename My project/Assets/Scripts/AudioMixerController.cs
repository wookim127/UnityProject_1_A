using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;

public class AudioMixerController : MonoBehaviour
{
    [SerializeField] private AudioMixer audioMixer;

    [SerializeField] private AudioMixer MusicMasterSlider;
    [SerializeField] private AudioMixer MusicBGMSlider;
    [SerializeField] private AudioMixer MusicSFXSlider;

    // Start is called before the first frame update

    
    public void SetMasterVolume(float volume)
    {
        audioMixer.SetFloat("Master", Mathf.Log10(volume) * 20);      //º¼·ý¿¡¼­ÀÇ 0 ~ 1 <- Mathf.Log10(volume) *20
    }
    public void SetBGMVolume(float volume)
    {
        audioMixer.SetFloat("BGM", Mathf.Log10(volume) * 20);      //º¼·ý¿¡¼­ÀÇ 0 ~ 1 <- Mathf.Log10(volume) *20
    }
    public void SetSFXVolume(float volume)
    {
        audioMixer.SetFloat("SFX", Mathf.Log10(volume) * 20);      //º¼·ý¿¡¼­ÀÇ 0 ~ 1 <- Mathf.Log10(volume) *20
    }
}        
