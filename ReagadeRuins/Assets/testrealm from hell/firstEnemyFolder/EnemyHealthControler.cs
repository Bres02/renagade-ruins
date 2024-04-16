using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealthControler : MonoBehaviour
{
    public EnemyScriptableObject enemyScript;
    int currentHealth;
    private void Awake()
    {
        currentHealth = enemyScript.maxHealth;
    }
    public void TakeDamae(int damage)
    {
        currentHealth -= damage;
        if (currentHealth <= 0)
        {
            Destroy(this.gameObject);
        }
    }
}
