using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class SpiderEnemy : MonoBehaviour
{
    private NavMeshAgent agent;
    private Animator animator;
    public GameObject bullet;
    private Transform targetLocation;
    private bool attacking = false;
    public Transform bulletSpawnPoint;

    private void Awake()
    {
        
    }
    public void setinfo(gamemaneger gameManger)
    {
        targetLocation = gameManger.playerRefrence.transform;
        animator = GetComponent<Animator>();
        agent = GetComponent<NavMeshAgent>();
        agent.destination = targetLocation.position;
    }

    // Update is called once per frame
    void Update()
    {
        if (!attacking)
        {
            agent.destination = targetLocation.position;
            Vector3 direction = (targetLocation.position - transform.position).normalized;
            Quaternion lookRotation = Quaternion.LookRotation(direction);
            transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, Time.deltaTime * 3f);



            // Check if player is within the angle range in front of the enemy
            float angle = Vector3.Angle(transform.forward, direction);
            if (angle < 5f) // Adjust the angle as needed
            {
                Debug.Log("hi");
                if (!agent.pathPending)
                {
                    if (agent.remainingDistance <= agent.stoppingDistance)
                    {
                        if (!agent.hasPath || agent.velocity.sqrMagnitude == 0f)
                        {
                            animator.SetBool("Is Walking", false);
                            animator.SetTrigger("Attacking");
                            attacking = true;
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
            else
            {
                animator.SetBool("Is Walking", true);
            }
        }
        else
        {
            agent.destination = this.transform.position;
        }

    }
    public void SpitAttack()
    {
        GameObject newBullet = Instantiate(bullet, bulletSpawnPoint.position, bulletSpawnPoint.rotation);
    }
    public void endAttack()
    {
        attacking = false;
        animator.SetBool("Is Walking", true);
    }
}
