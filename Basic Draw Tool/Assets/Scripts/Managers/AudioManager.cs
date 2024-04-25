using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AudioManager : MonoBehaviour
{
    public static AudioManager instance;
    public AudioSource audioSource;
    public AudioClip[] audioClips;
    
    [SerializeField] private GameObject backgroundMusic;
    [SerializeField] private Slider backgroundMusicVolumeSlider;
    
    void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void PlayAudioClip(int index)
    {
        audioSource.clip = audioClips[index];
        audioSource.Play();
    }
    
    
    public void ToggleBackgroundMusic()
    {
        AudioSource backgroundMusicAudio = backgroundMusic.GetComponent<AudioSource>();
        
        if (backgroundMusicAudio.isPlaying)
        {
            backgroundMusicAudio.Pause();
        }
        else
        {
            backgroundMusicAudio.Play();
        }
    }
    
    // adjust background music volume with slider
    public void AdjustBackgroundMusicVolume()
    {
        AudioSource backgroundMusicAudio = backgroundMusic.GetComponent<AudioSource>();
        backgroundMusicAudio.volume = backgroundMusicVolumeSlider.value;
    }
    
    
    
    
}
