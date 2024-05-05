using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.AI;

public class SpiderEnemy : MonoBehaviour
{
    public EnemyScriptableObject enemyScript;
    private NavMeshAgent agent;
    private Animator animator;
    private Transform targetLocation;
    private bool attacking = false;
    public Transform bulletSpawnPoint;
    private int currentHealth;
    private float range = 13f;
    public quaternion rotaiton;

    public void setinfo(gamemaneger gameManger)
    {
        targetLocation = gameManger.playerRefrence.transform;
        animator = GetComponent<Animator>();
        agent = GetComponent<NavMeshAgent>();
        agent.destination = targetLocation.position;
        currentHealth = enemyScript.maxHealth;
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
                if (!agent.pathPending)
                {
                    if (agent.remainingDistance <= 13f)
                    {
                        animator.SetBool("Is Walking", false);
                        animator.SetTrigger("Attacking");
                        attacking = true;
                        rotaiton = transform.rotation;
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
        if (attacking) 
        {
            transform.rotation = rotaiton;
        }
    }

    public void SpitAttack()
    {
        GameObject newBullet = Instantiate(enemyScript.projectile, bulletSpawnPoint.position, bulletSpawnPoint.rotation);
        newBullet.GetComponent<Bullet>().setValues(enemyScript.damage);
    }
    public void endAttack()
    {
        attacking = false;
        animator.SetBool("Is Walking", true);
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, range);
    }
}
