using UnityEngine;
using System.Collections;

public class AudioManager : MonoBehaviour
{
    public static AudioManager Instance;

    [Header("Audio Sources")]
    public AudioSource musicSource;
    public AudioSource sfxSource;

    [Header("Audio Clips")]
    public AudioClip mainTheme;
    public AudioClip[] soundEffects;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void Start()
    {
        PlayMusic(mainTheme);
    }

    public void PlayMusic(AudioClip clip)
    {
        musicSource.clip = clip;
        musicSource.Play();
    }

    public void PlaySoundEffect(int index)
    {
        if (index >= 0 && index < soundEffects.Length)
        {
            sfxSource.clip = soundEffects[index];
            sfxSource.Play();
        }
        else
        {
            Debug.LogWarning("Sound effect index out of range.");
        }
    }

    public void StopMusic()
    {
        musicSource.Stop();
    }

    public void StopSoundEffects()
    {
        sfxSource.Stop();
    }
}