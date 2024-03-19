using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttributeManager : MonoBehaviour
{
    public int health;
    public int attack;

    public void TakeDamage(int amount)
    {
        health -= amount;
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
