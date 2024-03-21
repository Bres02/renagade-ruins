using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

[CreateAssetMenu(fileName = "Data", menuName = "ScriptableObjects/EnemyScriptableObject", order = 2)]

public class EnemyScriptableObject : ScriptableObject
{
    public GameObject projectile;
    public int maxHealth;
    public int damage;
}
