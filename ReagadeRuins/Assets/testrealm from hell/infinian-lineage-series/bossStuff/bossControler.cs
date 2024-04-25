using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class bossControler : MonoBehaviour
{
    public float health;
    public AbiilityScriptableObject[] attacks;
    public Animator animator;

    public float attackCooldown;
    public float[] abilityCooldowns;
    public bool isCasting = false;
    public bool hasAbilityQued = false;
    public bool canAttack = true;

    public int abilityQued;
    
    public GameObject player;
    
    private NavMeshAgent agent;
    public gamemaneger gamemaneger;


    private void Awake()
    {
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
            if (attacks[abilityQued].range > Vector3.Distance(this.transform.position, gamemaneger.playerRefrence.transform.position) && canAttack)
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
        else
        {

        }

    }
    public void startcasting()
    {
        this.transform.GetChild(attacks[abilityQued].childLocation).gameObject.SetActive(true);
        animator.SetTrigger(attacks[abilityQued].triggerName);
    }

    public void abilityFinish()
    {
        this.transform.GetChild(attacks[abilityQued].childLocation).gameObject.SetActive(false);
        abilityCooldowns[abilityQued] = attacks[abilityQued].cooldown;
        attackCooldown = attacks[abilityQued].bosscooldown;
        isCasting = false;
        hasAbilityQued = false;
    }
    
}
