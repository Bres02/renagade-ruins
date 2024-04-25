using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "ScriptableObjects/boss/Abiility")]
public class AbiilityScriptableObject : ScriptableObject
{
    public string triggerName;
    public int childLocation;
    public int damage;
    public int casttime;
    public int ablilityRadius;
    public float range;
    public float cooldown;
    public float bosscooldown;
}
