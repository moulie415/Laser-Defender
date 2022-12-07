using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    [SerializeField] int health = 50;


    private void OnTriggerEnter2D(Collider2D other)
    {
        DamageDealer damagerDealer = other.GetComponent<DamageDealer>();

        if (damagerDealer != null)
        {
            TakeDamage(damagerDealer.GetDamage());
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
}
