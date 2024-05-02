using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class attackspawner : MonoBehaviour
{
    public attackEffects[] attackEffects;
    public GameObject gameManager;
    public GameObject projectile;
    public int damage;
    public GameObject spawnPoint;

    public void onActivate(int _damage)
    {
        damage = _damage;
        for (int i = 0; i < attackEffects.Length; i++)
        {
            attackEffects[i].effect(transform.parent.gameObject, gameManager, projectile, damage, spawnPoint.transform);
        }
    }
}
