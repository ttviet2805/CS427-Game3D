using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    [SerializeField] private int maxHealth = 5;
    [SerializeField] private float knockBackForce = 10f;
    [SerializeField] private float damageRecoveryTime = 1f;

    private int currentHealth;
    private bool canTakeDamage = true;
    private KnockBack knockBack;
    private Flash flash;

    private void Awake()
    {
        flash = GetComponent<Flash>();
        knockBack = GetComponent<KnockBack>();
    }

    private void Start()
    {
        currentHealth = maxHealth;
    }

    private void OnCollisionStay2D(Collision2D other)
    {
        if (!canTakeDamage) return;

        EnemyAI enemy = other.gameObject.GetComponent<EnemyAI>();
        if (!enemy) return;

        TakeDamage(1);
        knockBack.GetKnockedBack(other.gameObject.transform, knockBackForce);
        StartCoroutine(flash.FlashRoutine());
    }

    private void TakeDamage(int damage)
    {
        currentHealth -= damage;
        canTakeDamage = false;
        Debug.Log(currentHealth);
        StartCoroutine(DamageRecoveryRoutine());
    }

    private IEnumerator DamageRecoveryRoutine()
    {
        yield return new WaitForSeconds(damageRecoveryTime);
        canTakeDamage = true;
    }
}
