using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponAttributes : MonoBehaviour
{
    public AttributeManager atm;

    // Deals damage to enemy, specifically
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Enemy") || other.CompareTag("Boss"))
        {
            other.GetComponent<EnemyHealthControler>().TakeDamae(atm.attack);
        }
    }
}
