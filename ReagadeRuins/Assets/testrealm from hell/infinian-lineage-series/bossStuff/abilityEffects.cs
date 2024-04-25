using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class abilityEffects : ScriptableObject
{
    public abstract void abilityEffect(GameObject boss, GameObject player);
}
