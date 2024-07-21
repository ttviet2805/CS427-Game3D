using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Pickup : MonoBehaviour
{
    private enum PickupType
    {
        GoldCoin,
        HealthGlobe,
    }
    [SerializeField] private PickupType pickupType;
    [SerializeField] private float pickUpDistance = 5f;
    [SerializeField] private float accelarationRate = .2f;
    [SerializeField] private float moveSpeed = 3f;
    private Vector3 moveDir;
    private Rigidbody2D rb;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        Vector3 playerPos = PlayerController.Instance.transform.position;

        if (Vector3.Distance(playerPos, transform.position) < pickUpDistance)
        {
            moveDir = (playerPos - transform.position).normalized;
            moveSpeed += accelarationRate;
        }
        else
        {
            moveDir = Vector3.zero;
            moveSpeed = 0;
        }
    }

    private void FixedUpdate()
    {
        rb.velocity = moveDir * moveSpeed * Time.deltaTime;
    }

    private void OnTriggerStay2D(Collider2D other)
    {
        if (other.gameObject.GetComponent<PlayerController>())
        {
            DetectPickupType();
            Destroy(gameObject);
        }
    }

    private void DetectPickupType()
    {
        switch (pickupType)
        {
            case PickupType.GoldCoin:
                PlayerHealth.Instance.AddCoin();
                break;
            case PickupType.HealthGlobe:
                PlayerHealth.Instance.HealPlayer();
                break;
        }
    }
}
