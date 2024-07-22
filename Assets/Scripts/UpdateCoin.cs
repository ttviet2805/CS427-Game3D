using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpdateCoin : MonoBehaviour
{
    private void Awake()
    {
        PlayerHealth.Instance.UpdateCoinSlider();
        PlayerHealth.Instance.AudioMan = GameObject.FindGameObjectWithTag("Audio").GetComponent<AudioManager>();
    }
}
