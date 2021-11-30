using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Health : MonoBehaviour
{
    int _maxHealth = 15;
    public int _currentHealth;

    [SerializeField] ParticleSystem damageParticles;
    [SerializeField] ParticleSystem healParticles;
    [SerializeField] ParticleSystem dieParticles;
    [SerializeField] AudioClip damageAudio;
    [SerializeField] AudioClip healAudio;
    [SerializeField] AudioClip dieAudio;
    [SerializeField] AudioSource audioSource;
    [SerializeField] Transform spawn;

    Color origClr;
    [SerializeField] Renderer renderer;

    public HealthBar healthBar;


    private void Awake()
    {
        _currentHealth = _maxHealth;
        origClr = renderer.material.color;
    }

    private void Update()
    {
        healthBar.SetHealth(_currentHealth);
        if (_currentHealth <= 0)
        {
            Die();
        }
    }
    public void TakeDamage(int amount)
    {
        _currentHealth -= amount;
        ParticleSystem newDamageParticles = Instantiate(damageParticles, spawn.position, Quaternion.identity);
        audioSource.PlayOneShot(damageAudio);
        Flash();
    }

    public void Heal(int amount)
    {
        _currentHealth += amount;
        if(_currentHealth > _maxHealth)
        {
            _currentHealth = _maxHealth;
        }
        ParticleSystem newHealParticles = Instantiate(healParticles, spawn.position, Quaternion.identity);
        audioSource.PlayOneShot(healAudio);
    }

    private void Die()
    {
        ParticleSystem newDieParticles = Instantiate(dieParticles, spawn.position, Quaternion.identity);
        audioSource.PlayOneShot(dieAudio);
        this.gameObject.SetActive(false);
    }

    void Flash()
    {
        renderer.material.color = Color.white;
        Invoke("ResetColor", .1f);
    }

    void ResetColor()
    {
        renderer.material.color = origClr;
    }
}
