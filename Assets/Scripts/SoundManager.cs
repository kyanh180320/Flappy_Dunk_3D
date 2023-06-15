using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SoundManager : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] private Slider volumeSlider;
  
    [SerializeField] private Button soundButton;
    [SerializeField] private GameObject soundOnImageSettingUI, soundOffImageSettingUI;
    [SerializeField] private GameObject soundOnImagePauseUI, soundOffImagePauseUI;

    private bool muted = false;
    void Start()
    {
        if (!PlayerPrefs.HasKey("musicVolume"))
        {
            PlayerPrefs.SetFloat("musicVolume", 1);
            LoadVolume();
        }
        else
        {
            LoadVolume();
        }
        if (!PlayerPrefs.HasKey("muted"))
        {
            PlayerPrefs.SetInt("muted", 0);
            LoadBgMusic();
        }
        else
        {
            LoadBgMusic();
        }
        UpdateButtonIcon();
        AudioListener.pause = muted;
    }

    // Update is called once per frame
    void Update()
    {
      
    }
    //private void Load()
    //{
    //    volumeSlider.value = PlayerPrefs.GetFloat("musicVolume");
    //}
    //private void Save()
    //{
    //    PlayerPrefs.SetFloat("musicVolume", volumeSlider.value);
    //}
    public void OnButtonPress()
    {
        if (!muted)
        {
            muted = true;
            AudioListener.pause = true;
        }
        else
        {
            muted = false;
            AudioListener.pause = false;
        }
        SaveBgMusic();
        UpdateButtonIcon();
    }
    private void UpdateButtonIcon()
    {
        if (soundButton != null)
        {
            if (!muted)
            {
                soundOnImageSettingUI.SetActive(true);
                soundOffImageSettingUI.SetActive(false);
                soundOnImagePauseUI.SetActive(true);
                soundOffImagePauseUI.SetActive(false);
            }
            else
            {
                soundOffImageSettingUI.SetActive(true) ;
                soundOnImageSettingUI.SetActive(false);
                soundOffImagePauseUI.SetActive(true );
                soundOnImagePauseUI.SetActive(false);
            }
        }
    }
    private void LoadBgMusic()
    {
        muted = PlayerPrefs.GetInt("muted") == 1;
    }
    private void SaveBgMusic()
    {
        PlayerPrefs.SetInt("muted", muted ? 1 : 0);
    }
    private void SaveVolume()
    {
        PlayerPrefs.SetFloat("musicVolume", volumeSlider.value);
    }
    private void LoadVolume()
    {
        if (volumeSlider != null)
        {
            volumeSlider.value = PlayerPrefs.GetFloat("musicVolume");
        }
    }
    public void ChangeVolume()
    {
        AudioListener.volume = volumeSlider.value;
        SaveVolume();
    }
}

