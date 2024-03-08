using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Enemy : MonoBehaviour
{
    public NavMeshAgent agent;
    public Transform player;
    public LayerMask ground, player0;
    public float attackCooldown;
    public float attackRange;
    public bool inRange;
    public float moveSpeed = 3f;
    public int attackDamage = 10;
    public GameObject projectilePrefab;
    public Transform firePoint;
    public bool isRanged;
    public bool isRunner;
    //CharacterHealth playerHealth;
        

    private bool isAttacked;
    Animator _animator;
    private void Awake()
    {
        //_animator = GetComponent<Animator>();
        agent = GetComponent<NavMeshAgent>();

    }
    private void Start()
    {
        /* soldier = GameObject.Find("Soldier_demo");
         playerHealth = soldier.GetComponent<CharacterHealth>();*/
    }


    void Update()
    {   
        inRange = Physics.CheckSphere(transform.position, attackRange, player0);
        if (inRange /*&& playerHealth.currentHealth > 0*/)
        {
            Attack();
        }
        else
        {
            Chase();
        }
    }
    void Attack()
    {

    }
    void Chase()
    {
        if (isRunner == true)
        {
            Vector3 v3MeTowardsTarget = player.position - transform.position;
            agent.velocity += v3MeTowardsTarget.normalized * moveSpeed * Time.deltaTime;
        }
        else
        {
            agent.speed = moveSpeed;
            agent.SetDestination(player.position);
        }
    }
}

