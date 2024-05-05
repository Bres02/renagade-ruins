using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyHealthControler : MonoBehaviour
{
    public EnemyScriptableObject enemyScript;
    int currentHealth;
    public GameObject healthbar;
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
        if (healthbar != null)
        {
            healthbar.GetComponent<Slider>().value = currentHealth;

        }
    }
}
