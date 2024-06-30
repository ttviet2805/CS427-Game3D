using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : Singleton<PlayerHealth>
{
    [SerializeField] private int maxHealth = 5;
    [SerializeField] private float knockBackForce = 10f;
    [SerializeField] private float damageRecoveryTime = 1f;
    
    private Slider healthSlider;
    private int currentHealth;
    private bool canTakeDamage = true;
    private KnockBack knockBack;
    private Flash flash;

    protected override void Awake()
    {
        base.Awake();
        flash = GetComponent<Flash>();
        knockBack = GetComponent<KnockBack>();
    }

    private void Start()
    {
        currentHealth = maxHealth;
        UpdateHealthSlider();
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
        
        // Debug.Log(currentHealth);
        StartCoroutine(DamageRecoveryRoutine());
        UpdateHealthSlider();
    }

    private IEnumerator DamageRecoveryRoutine()
    {
        yield return new WaitForSeconds(damageRecoveryTime);
        canTakeDamage = true;
    }

    public void HealPlayer()
    {
        if (currentHealth >= maxHealth) return;
        currentHealth += 1;
        UpdateHealthSlider();
        // Debug.Log(currentHealth);
    }

    private void UpdateHealthSlider()
    {
        if (healthSlider == null)
        {
            healthSlider = GameObject.Find("Heart Slider").GetComponent<Slider>();
        }

        healthSlider.maxValue = maxHealth;
        healthSlider.value = currentHealth;
    }
}
