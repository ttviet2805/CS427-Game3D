using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerHealth : Singleton<PlayerHealth>
{
    [SerializeField] private int maxHealth = 5;
    [SerializeField] private float knockBackForce = 10f;
    [SerializeField] private float damageRecoveryTime = 1f;

    private Slider healthSlider;
    private TextMeshProUGUI coinSlider;

    private int currentHealth;
    private int currentCoin;
    private bool canTakeDamage = true;
    private KnockBack knockBack;
    private Flash flash;
    public AudioManager AudioMan;

    protected override void Awake()
    {
        base.Awake();
        flash = GetComponent<Flash>();
        knockBack = GetComponent<KnockBack>();
        AudioMan = GameObject.FindGameObjectWithTag("Audio").GetComponent<AudioManager>();
    }

    private void Start()
    {
        currentHealth = maxHealth;
        currentCoin = 0;
        UpdateHealthSlider();
        UpdateCoinSlider();
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
        AudioMan.PlaySFX(AudioMan.playerHurt);

        if (currentHealth <= 0)
        {
            AudioMan.PlaySFX(AudioMan.playerDeath);
            SceneManager.LoadScene("LoseScene");
        }
    }

    private IEnumerator DamageRecoveryRoutine()
    {
        yield return new WaitForSeconds(damageRecoveryTime);
        canTakeDamage = true;
    }

    public void HealPlayer()
    {
        if (currentHealth < maxHealth)
        {
            currentHealth += 1;
            UpdateHealthSlider();
        }
        AudioMan.PlaySFX(AudioMan.playerHeal);
    }

    public void UpdateHealthSlider()
    {
        if (healthSlider == null)
        {
            healthSlider = GameObject.Find("Heart Slider").GetComponent<Slider>();
        }

        healthSlider.maxValue = maxHealth;
        healthSlider.value = currentHealth;
    }

    public void AddCoin()
    {
        currentCoin += 1;
        UpdateCoinSlider();
        AudioMan.PlaySFX(AudioMan.coinPickup);
    }

    public void UpdateCoinSlider()
    {
        if (coinSlider == null)
        {
            coinSlider = GameObject.Find("Gold Coin Amount Text").GetComponent<TextMeshProUGUI>();
        }
        // Debug.Log(currentCoin);

        coinSlider.SetText(currentCoin.ToString(), true);
    }

    public void ResetPlayer()
    {
        currentHealth = maxHealth;
        currentCoin = 0;
        UpdateHealthSlider();
        UpdateCoinSlider();
    }
}
