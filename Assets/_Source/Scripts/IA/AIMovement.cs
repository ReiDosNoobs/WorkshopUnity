using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using Random = UnityEngine.Random;

public class AIMovement : MonoBehaviour
{
    private NavMeshAgent nav;

    [Header("Enemy Info")]
    public float attackRange;
    public float attackSpeed;
    public float currentAttackCooldown;
    public int[] attackDamage;
    public bool canAttack;

    [Header("Player Info")]
    public Transform player;
    // Start is called before the first frame update
    void Start()
    {
        nav = GetComponent<NavMeshAgent>();
        nav.stoppingDistance = attackRange;
    }

    // Update is called once per frame
    void Update()
    {
        Chase();
        if (player == null) return;

        if(Vector3.Distance(transform.position, player.position) < attackRange)
        {
            if (canAttack)
            {
                Attack();
            }
            else
            {
                currentAttackCooldown -= Time.deltaTime;

                if (currentAttackCooldown <= 0)
                {
                    canAttack = true;
                    currentAttackCooldown = attackSpeed;
                }
            }
        } 
    }

    void Chase()
    {
        nav.SetDestination(player.position);
    }

    void Attack()
    {
        canAttack = false;
        player.GetComponent<IDamageable>().TakeDamage(Random.Range(attackDamage[0], attackDamage[1]));
    }
}
