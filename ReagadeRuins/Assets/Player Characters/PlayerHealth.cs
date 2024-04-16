using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    public PlayerScriptable playerScript;
    int currentHealth;
    private void Awake()
    {
        currentHealth = playerScript.maxHealth;
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
