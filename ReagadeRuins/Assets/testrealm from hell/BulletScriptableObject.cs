using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Data", menuName = "ScriptableObjects/BulletScriptableObject", order = 1)]

public class BulletScriptableObject : ScriptableObject
{
    public float bulletSpeed;
    public float bulletDamage;

}
