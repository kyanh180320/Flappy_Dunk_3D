using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SoundManager : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] private Slider volumeSlider;
    //[SerializeField] Image soundOnIcon;
    //[SerializeField] Image soundOffIcon;
    [SerializeField] Sprite soundOnIcon, soundOffIcon;
    [SerializeField] private Button soundButton;
   
    private bool muted = false;
    void Start()
    {
      
        //if (!PlayerPrefs.HasKey("musicVolume"))
        //{
        //    PlayerPrefs.SetFloat("musicVolume", 1);
        //    Load();
        //}
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
    //public void ChangeVolume()
    //{
    //    AudioListener.volume = volumeSlider.value;
    //    SaveBgMusic();
    //}
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

                soundButton.GetComponent<Image>().sprite = soundOnIcon;
            }
            else
            {
                soundButton.GetComponent<Image>().sprite = soundOffIcon;
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

}

