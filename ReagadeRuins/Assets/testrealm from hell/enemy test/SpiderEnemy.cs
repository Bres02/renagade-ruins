using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class SpiderEnemy : MonoBehaviour
{
    private NavMeshAgent agent;
    private Animator animator;
    [SerializeField] private Transform targetLocation;

    private void Awake()
    {
        animator = GetComponent<Animator>();
        agent = GetComponent<NavMeshAgent>();
        agent.destination = targetLocation.position;
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        agent.destination = targetLocation.position;
        if (!agent.pathPending)
        {
            if (agent.remainingDistance <= agent.stoppingDistance)
            {
                if (!agent.hasPath || agent.velocity.sqrMagnitude == 0f)
                {
                    animator.SetBool("Is Walking", false);
                    animator.SetTrigger("Attacking");
                }
                else
                {
                    animator.SetBool("Is Walking", true);
                }
            }
            else
            {
                animator.SetBool("Is Walking", true);
            }
        }
        else
        {
            animator.SetBool("Is Walking", true);
        }
    }
    public void SpitAttack()
    {
        Debug.Log("chomp");
    }
}
