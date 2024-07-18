using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;

public class GalleryGameManager : MonoBehaviour
{
    private GameData gameData;

    public TextMeshProUGUI Money;
    public TextMeshProUGUI Cycle;
    
    [SerializeField] private AudioMixer GalleryaudioMixer;
    [SerializeField] private Slider MusicSlider;
    [SerializeField] private Slider SFXSlider;
    [SerializeField] private Slider MasterSlider;

    [SerializeField] private GameObject SettingsCanvas;
    [SerializeField] private GameObject BUTTONSCanvas;

    private void Awake()
    {
        SettingsCanvas.gameObject.SetActive(false);
        MusicSlider.value = 1f;
        SFXSlider.value = 1f;
        MasterSlider.value = 1f;
        //LoadVolume();
        RefreshUI();
    }

    void RefreshUI()
    {
        Money.text = gameData.Totalmoney.ToString();
        Cycle.text = "Hari Ke " + gameData.CyclePassed.ToString();

    }

    public void OpenSettingsButton()
    {
        SettingsCanvas.gameObject.SetActive(true);
        BUTTONSCanvas.gameObject.SetActive(false);
    }

    public void CloseSettingsButton()
    {
        SettingsCanvas.gameObject.SetActive(false);
        BUTTONSCanvas.gameObject.SetActive(true) ;
    }

    public void UpdateMusicVolume(float volume)
    {
        GalleryaudioMixer.SetFloat("Music", Mathf.Log10(volume) * 20f);
    }

    public void UpdateSFXVolume(float volume)
    {
        GalleryaudioMixer.SetFloat("SFX", Mathf.Log10(volume) * 20f);
    }

    public void UpdateMasterVolume(float volume)
    {
        GalleryaudioMixer.SetFloat("Master", Mathf.Log10(volume) * 20f);
    }

    public void SaveVolume()
    {
        GalleryaudioMixer.GetFloat("Music", out float musicVolume);
        PlayerPrefs.SetFloat("Music", musicVolume);

        GalleryaudioMixer.GetFloat("SFX", out float sfxVolume);
        PlayerPrefs.SetFloat("SFX", sfxVolume);

        GalleryaudioMixer.GetFloat("Master", out float masterVolume);
        PlayerPrefs.SetFloat("Master", masterVolume);
    }

    public void LoadVolume()
    {
        MusicSlider.value =  PlayerPrefs.GetFloat("Music");
        SFXSlider.value = PlayerPrefs.GetFloat("SFX");
        MasterSlider.value = PlayerPrefs.GetFloat("Master");
    }
}
