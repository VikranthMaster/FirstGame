using UnityEngine;
using System;

public class Target : MonoBehaviour
{
    public int maxHealth = 100;

    public void TakeDamage (int amount)
    {
        maxHealth -= amount;
        if (maxHealth <= 0f)
        {
            Die();
        }
    }
    void Die()
    {
        Destroy(gameObject);
    }

}
