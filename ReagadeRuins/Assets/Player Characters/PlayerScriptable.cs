using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Data", menuName = "ScriptableObjects/PlayerScriptable")]

public class PlayerScriptable : ScriptableObject
{
    public GameObject leftWeapon;
    public int leftWeaponDamage;
    public GameObject rightWeapon;
    public int rightWeaponDamage;
    public int maxHealth;
    public float moveSpeed;
}
