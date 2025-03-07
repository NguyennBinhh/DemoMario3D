using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundController : MonoBehaviour
{
    public static SoundController instance;

    private void Awake()
    {
        if(instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        } else
        {
            Destroy(gameObject);
        }

        if (!PlayerPrefs.HasKey("Sound_SFX") && !PlayerPrefs.HasKey("Sound_Music"))
        {
            PlayerPrefs.SetFloat("Sound_Music", 1);
            PlayerPrefs.SetFloat("Sound_SFX", 1);
            PlayerPrefs.SetString("Music", "flase");
            PlayerPrefs.SetString("SFX", "false");
        }
    }



    public void SetSound_Music(float vol)
    {
        PlayerPrefs.SetFloat("Sound_Music", vol);
    }

    public void SetSound_SFX(float vol)
    {
        PlayerPrefs.SetFloat("Sound_SFX", vol);
    }

    public void SetEnableMusic(int check)
    {
        PlayerPrefs.SetInt("Music", check);
    }

    public void SetEnableSFX(int check)
    {
        PlayerPrefs.SetInt("SFX", check);
    }
}
