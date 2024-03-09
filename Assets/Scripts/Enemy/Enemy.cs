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
    PlayerHealth playerHealth;


    private bool isAttacked;
    Animator _animator;
    private void Awake()
    {
        playerHealth = player.GetComponent<PlayerHealth>();
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
        if (inRange)
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
        transform.LookAt(player);
        agent.SetDestination(transform.position);

        if (!isAttacked)
        {

            if (isRanged)
            {

                //Vector3 _rotation = new Vector3(firePoint.rotation.x, firePoint.rotation.y, firePoint.rotation.z - 90);
                GameObject arrow = Instantiate(projectilePrefab, firePoint.position, firePoint.rotation);
                //arrow.transform.rotation = Quaternion.Euler(_rotation);

                Vector3 direction = player.position - transform.position;
                direction.Normalize();


                Rigidbody arrowRigidbody = arrow.GetComponent<Rigidbody>();
                arrowRigidbody.velocity = direction * 20f;
                //Debug.Log(sphereRigidbody.velocity);
                //_animator.SetBool("Attack", true);
            }
            if (!isRanged)
            {
                //_animator.SetBool("Attack", true);
                playerHealth.takeDamage(attackDamage);
            }

            isAttacked = true;
            Invoke("AttackCooldown", attackCooldown);
        }
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
    void AttackCooldown()
    {
        //_animator.SetBool("Attack", false);
        isAttacked = false;

    }
}

