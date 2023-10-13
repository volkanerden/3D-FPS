using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    [SerializeField] float currentHealth;
    DeathHandler handler;
    float maxHealth = 100f;

    void Start()
    {
        currentHealth = maxHealth;
        handler = GetComponent<DeathHandler>();
    }
    public void TakeDamage(float damage)
    {
        currentHealth -= damage;
        if(currentHealth <= 0)
        {
            handler.HandleDeath();
            currentHealth = 0;
        }
    }
}
