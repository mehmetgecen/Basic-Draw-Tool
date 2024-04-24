using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public static AudioManager instance;
    public AudioSource audioSource;
    public AudioClip[] audioClips;
    
    [SerializeField] private GameObject backgroundMusic;
    
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
}
