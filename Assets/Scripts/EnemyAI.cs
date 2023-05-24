using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyAI : MonoBehaviour
{
    public NavMeshAgent agent;
    public Transform player;
    public LayerMask whatGround, whatPlayer;

    public Vector3 walkPoint;
    bool walkPointSet;
    public float walkPointRange;

    public float timeBetweenAttacks;
    bool attacked;

    public float sightR, attackR;
    public bool playerInSightR, playerInAttackR;
    // Start is called before the first frame update
    void Awake()
    {
        player = GameObject.Find("Player").transform;
        agent = GetComponent<NavMeshAgent>();
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        playerInSightR = Physics.CheckSphere(transform.position, sightR, whatPlayer);
        playerInAttackR = Physics.CheckSphere(transform.position, attackR, whatPlayer);

        if (!playerInSightR && !playerInAttackR) Patroling();
        if (playerInSightR && !playerInAttackR) ChasePlayer();
        if (playerInSightR && playerInAttackR) AttackPlayer();
    }

    private void Patroling()
    {
        if (!walkPointSet) SearchWalkPoint();
    }
    private void SearchWalkPoint()
    {
        //Stopped at 2:19
    }

    private void ChasePlayer()
    {

    }

    private void AttackPlayer()
    {

    }
}
