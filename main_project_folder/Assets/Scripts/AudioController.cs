using System;
using UnityEngine;
using UnityEngine.AdaptivePerformance.Provider;

public class AudioController : MonoBehaviour
{
    [SerializeField] private AudioClip bgMusic;
    [SerializeField] private AudioClip jumpSFX;
    [SerializeField] private AudioClip deathSFX;

    [SerializeField] private AudioSource musicSource;
    [SerializeField] private AudioSource sfxSource;

    void Start()
    {
        PlayBGMusic();
    }

    public void PlayJumpSFX()
    {
        sfxSource.clip = jumpSFX;
        sfxSource.Play();
    }

    public void PlayDeathSFX()
    {
        sfxSource.clip = deathSFX;
        sfxSource.Play();
    }

    public void PlayBGMusic()
    {
        musicSource.clip = bgMusic;
        musicSource.Play();
    }
}
