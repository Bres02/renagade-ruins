using System.Collections;
using System.Collections.Generic;
using JetBrains.Annotations;
using UnityEngine;

public abstract class attackEffects : ScriptableObject
{
    public abstract void effect(GameObject origin, GameObject gamemanager, GameObject projectile, int damage, Transform location);
}
