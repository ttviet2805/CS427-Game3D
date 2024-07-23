using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    [SerializeField] AudioSource SFXSource;
    [SerializeField] AudioSource musicSource;

    public AudioClip backgroundMusic;
    public AudioClip coinPickup;
    public AudioClip playerHurt;
    public AudioClip playerDeath;
    public AudioClip playerJump;
    public AudioClip playerAttack;
    public AudioClip playerHeal;
    public AudioClip portalIn;
    public AudioClip attackSound;

    private void Start()
    {
        musicSource.clip = backgroundMusic;
        musicSource.Play();
    }
    public void PlaySFX(AudioClip clip)
    {
        if (clip == null)
        {
            return;
        }
        SFXSource.PlayOneShot(clip);
    }

    public void SetVolume(float volume)
    {
        // SFXSource.volume = volume;
        musicSource.volume = volume;
    }

}
