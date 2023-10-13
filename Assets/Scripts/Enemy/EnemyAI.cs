using System;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.AI;

public class EnemyAI : MonoBehaviour
{
    Transform target;
    [SerializeField] float chaseRange = 5f;
    [SerializeField] float turnSpeed = 5f;

    NavMeshAgent navMeshAgent;
    Animator animator;
    EnemyHealth health;

    float distanceToTarget = Mathf.Infinity;
    bool isProvoked = false;
    
    void Start()
    {
        navMeshAgent = GetComponent<NavMeshAgent>();
        animator = GetComponent<Animator>();
        target = GameObject.FindGameObjectWithTag("Player").transform;
        health = GetComponent<EnemyHealth>();
    }

    void Update()
    {
        if(health.IsDead)
        {
            enabled = false;
        }

        if(isProvoked)
        {
            EngageTarget();
        }
        else if(distanceToTarget <= chaseRange) 
        {
            isProvoked = true;
        }

        distanceToTarget = Vector3.Distance(target.position, transform.position);

    }

    public void OnDamageTaken()
    {
        isProvoked= true;
    }

    void EngageTarget()
    {
        FaceTarget();
        if (distanceToTarget <= navMeshAgent.stoppingDistance)
        {
            AttackTarget();
        }
        if (distanceToTarget >= navMeshAgent.stoppingDistance)
        {   
            ChaseTarget();
        }
    }

    void ChaseTarget()
    {
        animator.SetBool("attack", false);
        animator.SetTrigger("move");
        navMeshAgent.SetDestination(target.position);
    }

    void FaceTarget()
    {
        Vector3 direction = (target.position - transform.position).normalized;
        Quaternion lookRotation = Quaternion.LookRotation(new Vector3(direction.x, 0, direction.z));
        transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, Time.deltaTime * turnSpeed);
    }

    void AttackTarget()
    {
        animator.SetBool("attack", true);
    }

    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, chaseRange);
    }
}