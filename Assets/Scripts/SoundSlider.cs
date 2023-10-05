using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;

public class SoundSlider : MonoBehaviour
{
    [SerializeField] Slider soundSlider;
    [SerializeField] AudioMixer masterMixer;

    // Start is called before the first frame update
    void Start()
    {
        SetVolume(PlayerPrefs.GetFloat("SavedMasterVolume", 100));
    }

    public void SetVolume(float soundValue)
    {
        if(soundValue < 1)
        {
            soundValue = 0.001f;
        }
        RefreshSlider(soundValue);
        PlayerPrefs.SetFloat("SavedMasterVolume", soundValue);
        masterMixer.SetFloat("MasterVolume", Mathf.Log10(soundValue / 100) * 20f);
    }
    
    public void SetVolumeFromSlider()
    {
        SetVolume(soundSlider.value);
    }

    public void RefreshSlider(float soundValue)
    {
        soundSlider.value = soundValue;
    }
}
