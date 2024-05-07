using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyHealthControler : MonoBehaviour
{
    public EnemyScriptableObject enemyScript;
    public int currentHealth;
    public GameObject healthbar;
    public GameObject gameManager;


    private void Awake()
    {
        gameManager = GameObject.Find("GameManeger");
        currentHealth = enemyScript.maxHealth;
    }
    public void TakeDamae(int damage)
    {
        currentHealth -= damage;

        if (currentHealth <= 0)
        {
            gameManager.GetComponent<gamemaneger>().RemoveEnemie();
            Destroy(this.gameObject);
        }
        if (healthbar != null)
        {
            healthbar.GetComponent<Slider>().value = currentHealth;
        }
    }
}
