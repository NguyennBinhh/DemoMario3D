
using UnityEngine;
using UnityEngine.UI;

public class SoundManager : MonoBehaviour
{
    [Header("Music Clip")]
    [SerializeField] private AudioSource Music;
    [SerializeField] private AudioSource SFX;
    [SerializeField] public AudioClip ClickClips;
    [SerializeField] private AudioClip MusicClip;

    private void Start()
    {
        Play_Music();
    }

    private void Play_Music()
    {
        this.Music.clip = MusicClip;
        this.Music.Play();
        
    }    

    public void Play_SFX(AudioClip clip)
    {
        this.SFX.clip = clip;
        this.SFX.PlayOneShot(clip);
    } 
    
    public void SetVolMusic()
    {
        Music.volume = PlayerPrefs.GetFloat("Sound_Music");
    }    
}
