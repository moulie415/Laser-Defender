using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    [SerializeField] int health = 50;
    [SerializeField] ParticleSystem hitEffect;

    [SerializeField] bool applyCameraShake;
    CameraShake cameraShake;


    private void Awake()
    {
        cameraShake = Camera.main.GetComponent<CameraShake>();
    }


    private void OnTriggerEnter2D(Collider2D other)
    {
        DamageDealer damagerDealer = other.GetComponent<DamageDealer>();

        if (damagerDealer != null)
        {
            TakeDamage(damagerDealer.GetDamage());
            PlayHitEffect();
            ShakeCamera();
            damagerDealer.Hit();
        }
    }

    void TakeDamage(int amount)
    {
        health -= amount;
        if (health <= 0)
        {
            Destroy(gameObject);
        }
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
}
