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
    public GameObject bullet;
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

        if (walkPointSet)
            agent.SetDestination(walkPoint);

        Vector3 distToWalkPoint = transform.position -walkPoint;

        if(distToWalkPoint.magnitude < 1f)
            walkPointSet = false;
    }
    private void SearchWalkPoint()
    {
        float randomX = Random.Range(-walkPointRange, walkPointRange);
        float randomZ = Random.Range(-walkPointRange, walkPointRange);

        walkPoint = new Vector3(transform.position.x + randomX, transform.position.y, transform.position.z + randomZ);
        if (Physics.Raycast(walkPoint, -transform.up, 2f, whatGround))
            walkPointSet = true;
    }

    private void ChasePlayer()
    {
        agent.SetDestination(player.position);
    }

    private void AttackPlayer()
    {
        agent.SetDestination(transform.position);
        transform.LookAt(player);

        if(!attacked)
        {
            GameObject clone;
            clone = Instantiate(bullet, transform.position, transform.rotation);
            attacked = true;
            Invoke(nameof(ResetAttack), timeBetweenAttacks);
        }
    }

    private void ResetAttack()
    {
        attacked = false;
    }
}
