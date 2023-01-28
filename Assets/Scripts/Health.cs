using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    [SerializeField] int health = 50;
    [SerializeField] int score = 50;
    [SerializeField] ParticleSystem hitEffect;

    [SerializeField] bool applyCameraShake;
    CameraShake cameraShake;

    AudioPlayer audioPlayer;

    [SerializeField] bool isPlayer;

    ScoreKeeper scoreKeeper;


    private void Awake()
    {
        cameraShake = Camera.main.GetComponent<CameraShake>();
        audioPlayer = FindObjectOfType<AudioPlayer>();
        scoreKeeper = FindObjectOfType<ScoreKeeper>();
    }


    private void OnTriggerEnter2D(Collider2D other)
    {
        DamageDealer damagerDealer = other.GetComponent<DamageDealer>();

        if (damagerDealer != null)
        {
            TakeDamage(damagerDealer.GetDamage());
            PlayHitEffect();
            audioPlayer.PlayDamageClip();
            ShakeCamera();
            damagerDealer.Hit();
        }
    }

    void TakeDamage(int amount)
    {
        health -= amount;
        if (health <= 0)
        {
            Die();
           
        }
    }

    void Die()
    {
        if (!isPlayer && scoreKeeper != null)
        {
            scoreKeeper.ModifyScore(10);
        }
        Destroy(gameObject);
    }

    void PlayHitEffect()
    {
        if (hitEffect != null)
        {
            ParticleSystem instance = Instantiate(hitEffect, transform.position, Quaternion.identity);
            Destroy(instance.gameObject, instance.main.duration + instance.main.startLifetime.constantMax);
        }
    }

    void ShakeCamera()
    {
        if (cameraShake != null  && applyCameraShake)
        {
            cameraShake.Play();
        }
    }

    public float GetHealth()
    {
        return health;
    }
}
