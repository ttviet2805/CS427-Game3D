using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicManager : Singleton <MusicManager>
{
    public AudioManager AudioMan;

    // Start is called before the first frame update
    void Start()
    {
        AudioMan = GameObject.FindGameObjectWithTag("Audio").GetComponent<AudioManager>();
    }

    public void PlaySFX(string cur)
    {
        if(cur == "Coin Pickup") AudioMan.PlaySFX(AudioMan.coinPickup);
        if(cur == "Player Hurt") AudioMan.PlaySFX(AudioMan.playerHurt);
        if(cur == "Player Death") AudioMan.PlaySFX(AudioMan.playerDeath);
        if(cur == "Player Heal") AudioMan.PlaySFX(AudioMan.playerHeal);
        if(cur == "Player Jump") AudioMan.PlaySFX(AudioMan.playerJump);
        if(cur == "Player Attack") AudioMan.PlaySFX(AudioMan.playerAttack);
        if(cur == "Portal In") AudioMan.PlaySFX(AudioMan.portalIn);
        if(cur == "Attack Sound") AudioMan.PlaySFX(AudioMan.attackSound);
    }

    public void SetVolume(float volume)
    {
        AudioMan.SetVolume(volume);
    }

    // Update is called once per frame
    void Update()
    {

    }
}