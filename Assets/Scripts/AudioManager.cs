using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    [SerializeField] AudioSource SFXSource;

    public AudioClip backgroundMusic;
    public AudioClip coinPickup;
    public AudioClip playerHurt;
    public AudioClip playerDeath;
    public AudioClip playerJump;
    public AudioClip playerAttack;
    public AudioClip playerHeal;
    public AudioClip portalIn;
    public AudioClip attackSound;
    public void PlaySFX(AudioClip clip)
    {
        if (clip == null)
        {
            return;
        }
        SFXSource.PlayOneShot(clip);
    }

}
