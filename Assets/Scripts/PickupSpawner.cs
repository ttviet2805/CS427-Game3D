using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickupSpawner : MonoBehaviour
{
    [SerializeField] private GameObject goldCoin, healthGlobe;
    public void DropItems()
    {
        int num = Random.Range(1, 3);
        if (num == 1)
            Instantiate(goldCoin, transform.position, Quaternion.identity);
        else
            Instantiate(healthGlobe, transform.position, Quaternion.identity);
    }
}
