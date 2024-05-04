using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "ScriptableObjects/presist")]
public class persistdata : ScriptableObject
{
    public int[] pickScenes;
    public int maxHealth;
    public int currentHealth;
    public int currentScene;
}
