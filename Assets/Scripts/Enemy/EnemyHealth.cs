using System;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    float maxHealth = 50f;
    float currentHealth;
    int killCount = 0;
    bool isDead = false;
    public bool IsDead {  get { return isDead; } }

    private void Awake()
    {
        currentHealth = maxHealth;
    }

    public void TakeDamage(float damage)
    {
        BroadcastMessage("OnDamageTaken");
        currentHealth -= damage;
        if (currentHealth <= 0)
        {
            Die();
            killCount++;
        }
    }

    private void Die()
    {
        if(isDead) return;
        isDead = true;
        GetComponent<Animator>().SetTrigger("die");
    }
}
