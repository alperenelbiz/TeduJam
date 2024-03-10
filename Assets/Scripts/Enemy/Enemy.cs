using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using static UnityEngine.GraphicsBuffer;

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

    GameObject realPlayer;
    private void Awake()
    {
        player = GameObject.Find("Player/FirstPersonCharacter").GetComponent<Transform>();
        playerHealth = player.GetComponent<PlayerHealth>();
        _animator = GetComponent<Animator>();
        agent = GetComponent<NavMeshAgent>();
        realPlayer = GameObject.Find("FirstPersonCharacter");

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
        Vector3 targetDirection = player.position - transform.position;
        Quaternion targetRotation = Quaternion.LookRotation(targetDirection);
        transform.rotation = Quaternion.Lerp(transform.rotation, targetRotation, Time.deltaTime * 5);

        //transform.LookAt(player);
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
                arrowRigidbody.velocity = direction * 40f;
                //Debug.Log(sphereRigidbody.velocity);

            }
            if (!isRanged)
            {

                _animator.SetBool("isInRange", false);
                _animator.SetTrigger("isAttacked");
                playerHealth.takeDamage(attackDamage);
            }

            isAttacked = true;
            Invoke("AttackCooldown", attackCooldown);
        }
    }
    void Chase()
    {



        _animator.SetBool("isInRange", true);
        agent.speed = moveSpeed;
        agent.SetDestination(player.position);

    }
    void AttackCooldown()
    {
        //_animator.SetBool("Attack", false);
        isAttacked = false;

    }
}