using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpdateCoin : MonoBehaviour
{
    private void Awake()
    {
        PlayerHealth.Instance.UpdateCoinSlider();
    }
}
