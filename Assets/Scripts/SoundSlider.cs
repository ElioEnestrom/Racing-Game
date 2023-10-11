using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;
using Unity.PlasticSCM.Editor.WebApi;

public class SoundSlider : MonoBehaviour
{
    [SerializeField] Slider soundSlider;
    [SerializeField] AudioMixer masterMixer;

    // Start is called before the first frame update
    void Start()
    {
        SetVolume(PlayerPrefs.GetFloat("SavedMasterVolume", 100));
    }

    //Changes the volume
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
    //Sets the volume from the slider
    public void SetVolumeFromSlider()
    {
        SetVolume(soundSlider.value);
    }

    //Changes volume from the slider
    public void RefreshSlider(float soundValue)
    {
        soundSlider.value = soundValue;
    }
}
