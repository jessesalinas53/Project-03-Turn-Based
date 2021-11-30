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


    private void Awake()
    {
        _currentHealth = _maxHealth;
    }

    private void Update()
    {
        if(_currentHealth <= 0)
        {
            Die();
        }
    }
    public void TakeDamage(int amount)
    {
        _currentHealth -= amount;
        //damageParticles.Play();
        ParticleSystem newDamageParticles = Instantiate(damageParticles, spawn.position, Quaternion.identity);
        audioSource.PlayOneShot(damageAudio);
    }

    public void Heal(int amount)
    {
        _currentHealth += amount;
        ParticleSystem newHealParticles = Instantiate(healParticles, spawn.position, Quaternion.identity);
        audioSource.PlayOneShot(healAudio);
    }

    private void Die()
    {
        ParticleSystem newDieParticles = Instantiate(dieParticles, spawn.position, Quaternion.identity);
        audioSource.PlayOneShot(dieAudio);
        this.gameObject.SetActive(false);
    }
}
