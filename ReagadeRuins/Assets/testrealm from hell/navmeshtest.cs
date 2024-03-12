using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class navmeshtest : MonoBehaviour
{
    private NavMeshAgent agent;
    private Animator animator;
    [SerializeField] private Transform targetLocation;
    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        agent = GetComponent<NavMeshAgent>();
        agent.destination = targetLocation.position;
    }

    // Update is called once per frame
    void Update()
    {
        agent.destination = targetLocation.position;
        if (agent.hasPath)
        {
            var dir = (agent.steeringTarget - transform.position).normalized;
            var animDir = transform.InverseTransformDirection(dir);
            animator.SetFloat("Horizontal", animDir.x);
            animator.SetFloat("Vertical", animDir.z);

        }
        else
        {
            animator.SetFloat("Horizontal", 0);
            animator.SetFloat("Vertical", 0);
        }
        agent.destination = targetLocation.position;
        if (!agent.pathPending)
        {
            if (agent.remainingDistance <= agent.stoppingDistance)
            {
                if (!agent.hasPath || agent.velocity.sqrMagnitude == 0f)
                {
                    Debug.Log("done");
                }
            }
        }
    }
}
