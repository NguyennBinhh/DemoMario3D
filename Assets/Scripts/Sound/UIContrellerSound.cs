
using UnityEngine;
using UnityEngine.UI;

public class UIContrellerSound : MonoBehaviour
{
    [SerializeField] private AudioSource[] MusicSound;
    [SerializeField] private AudioSource[] SFXSound;

    [SerializeField] private Slider Slider_Music;
    [SerializeField] private Slider Slider_SFX;
    [SerializeField] private Toggle CheckBox_Music;
    [SerializeField] private Toggle CheckBox_SFX;

    private void Start()
    {
        
        this.Slider_Music.value = PlayerPrefs.GetFloat("Sound_Music");
        this.Slider_SFX.value = PlayerPrefs.GetFloat("Sound_SFX");
        this.CheckBox_Music.isOn = PlayerPrefs.GetInt("Music", 1) == 1;
        this.CheckBox_SFX.isOn = PlayerPrefs.GetInt("SFX", 1) == 1;
        LoadDataSound();
    }

    public void MusicVol()
    {
        
        SoundController.instance.SetSound_Music(this.Slider_Music.value);
        for(int i = 0; i < this.MusicSound.Length; i++)
        {
            this.MusicSound[i].volume = this.Slider_Music.value; 
        }    
    }

    public void SFXVol()
    {
        for (int i = 0; i < this.SFXSound.Length; i++)
        {
            this.SFXSound[i].volume = this.Slider_SFX.value;
        }
        SoundController.instance.SetSound_SFX(this.Slider_SFX.value);

    }

    public void Toggle_Music()
    {
        for (int i = 0; i < this.MusicSound.Length; i++)
        {
            this.MusicSound[i].mute = !this.CheckBox_Music.isOn;
        }
        SoundController.instance.SetEnableMusic(this.CheckBox_Music.isOn ? 1 : 0);
    }

    public void Toggle_SFX()
    {
        for (int i = 0; i < this.SFXSound.Length; i++)
        {
            this.SFXSound[i].mute = !this.CheckBox_SFX.isOn;
        }
        SoundController.instance.SetEnableSFX(this.CheckBox_SFX.isOn ? 1 : 0);
    }

    private void LoadDataSound()
    {
        for (int i = 0; i < this.MusicSound.Length; i++)
        {
            this.MusicSound[i].volume = PlayerPrefs.GetFloat("Sound_Music");
            this.MusicSound[i].mute = PlayerPrefs.GetInt("Music", 1) != 1;
        }
        for (int i = 0; i < this.SFXSound.Length; i++)
        {
            this.SFXSound[i].volume = PlayerPrefs.GetFloat("Sound_SFX");
            this.SFXSound[i].mute = PlayerPrefs.GetInt("SFX", 1) != 1;
        }
    }    
}
