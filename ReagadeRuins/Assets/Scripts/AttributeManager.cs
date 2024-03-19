using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class AttributeManager : MonoBehaviour
{
    public int health;
    public int attack;

    public void TakeDamage(int amount)
    {
        health -= amount;

        if (health <= 0)
        {
            // TODO
            // Currently only for active scene, will need to change for starting screen/game over screen to replace.
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        } 
    }

    public void DealDamage(GameObject target)
    {
        var am = target.GetComponent<AttributeManager>();
        if (am != null)
        {
            am.TakeDamage(attack);
        }
        
    }
}
