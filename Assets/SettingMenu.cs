using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;
using TMPro;

public class SettingMenu : MonoBehaviour
{
    public TMP_Dropdown graphicsDropdown;
    public Slider musicVol;
    public AudioMixer mainAudioMixer;
    public void ChangeGraphicsQuality()
    {
        QualitySettings.SetQualityLevel(graphicsDropdown.value);
    }

    public void ChangeMusicVolume()
    {
        MusicManager.Instance.SetVolume(musicVol.value);
    }

    // Start is called before the first frame update
    void Start()
    {
        // graphicsDropdown.value = QualitySettings.GetQualityLevel();
        // mainAudioMixer.SetFloat("MusicVolume", -80);
        musicVol.value = musicVol.maxValue;
    }

    // Update is called once per frame
    void Update()
    {

    }
}
