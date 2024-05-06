using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class bossControler : MonoBehaviour
{
    public AbiilityScriptableObject[] attacks;
    public Animator animator;

    public float attackCooldown;
    public float[] abilityCooldowns;
    public bool isCasting = false;
    public bool hasAbilityQued = false;
    public bool canAttack = true;

    public int abilityQued;
    
    public GameObject player;
    public Transform attacklocation;
    
    private NavMeshAgent agent;
    public gamemaneger gamemaneger;


    private void Awake()
    {
        gamemaneger.addEnemie();
        agent = GetComponent<NavMeshAgent>();
        for (int i = 0; i < attacks.Length; i++)
        {
            abilityCooldowns[i] = attacks[i].cooldown;
        }
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (!isCasting)
        {
            if (attackCooldown > 0)
            {
                attackCooldown -= Time.deltaTime;
            }
            else
            {
                canAttack = true;
            }
            for (global::System.Int32 i = 0; i < abilityCooldowns.Length; i++)
            {
                if (abilityCooldowns[i]>0 )
                {
                    abilityCooldowns[i] -= Time.deltaTime;
                }
            }


            if (!hasAbilityQued)
            {

                for ( int i = 0;  i < abilityCooldowns.Length; i++)
                {
                    if (abilityCooldowns[i] <= 0 && !hasAbilityQued)
                    {
                        hasAbilityQued = true;
                        abilityQued = i;
                    }
                }
            }
            if (abilityQued >= 0)
            {
                agent.destination = gamemaneger.playerRefrence.transform.position;
                Vector3 direction = (gamemaneger.playerRefrence.transform.position - transform.position).normalized;
                Quaternion lookRotation = Quaternion.LookRotation(direction);
                transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, Time.deltaTime * 3f);
                float angle = Vector3.Angle(transform.forward, direction);

                if (attacks[abilityQued].range > Vector3.Distance(this.transform.position, gamemaneger.playerRefrence.transform.position) && canAttack && angle < 5f)
                {
                    agent.destination = this.transform.position;
                    isCasting = true;
                    startcasting();
                    canAttack = false;
                }
                else
                {
                    agent.destination = gamemaneger.playerRefrence.transform.position;
                }
            }
            

        }
        else
        {

        }

    }
    public void startcasting()
    {
        this.transform.GetChild(attacks[abilityQued].childLocation).gameObject.SetActive(true);
        animator.SetTrigger(attacks[abilityQued].triggerName);
        if (attacks[abilityQued].isSpawned)
        {
            this.transform.GetChild(attacks[abilityQued].childLocation).gameObject.GetComponent<attackspawner>().onActivate(attacks[abilityQued].damage);
        }
    }

    public void abilityFinish()
    {
        this.transform.GetChild(attacks[abilityQued].childLocation).gameObject.SetActive(false);
        abilityCooldowns[abilityQued] = attacks[abilityQued].cooldown;
        attackCooldown = attacks[abilityQued].bosscooldown;
        isCasting = false;
        hasAbilityQued = false;
        abilityQued = -1;
    }

    public void stop()
    {
        animator.SetTrigger("stop");
    }
    
}
