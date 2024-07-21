using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickupSpawner : MonoBehaviour
{
    [SerializeField] private GameObject goldCoin, healthGlobe;
    public void DropItems()
    {
        int num = Random.Range(1, 5);
        if (num <= 3)
            Instantiate(goldCoin, transform.position, Quaternion.identity);
        else
            Instantiate(healthGlobe, transform.position, Quaternion.identity);
    }
}
