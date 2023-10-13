using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttack : MonoBehaviour
{
    Transform target;
    PlayerHealth player;
    float enemyDamage = 5f;


    void Start()
    {
        player = FindObjectOfType<PlayerHealth>();
        target = GameObject.FindGameObjectWithTag("Player").transform;
    }
    public void AttackHitEvent()
    {
        player.TakeDamage(enemyDamage);
    }
}