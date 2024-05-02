using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "ScriptableObjects/boss/basicAttackEffects")]
public class basicAttack : attackEffects
{
    public override void effect(GameObject origin, GameObject gamemanager, GameObject projectile, int damage, Transform location)
    {
        GameObject newBullet = Instantiate(projectile, location.position, location.rotation);
        projectile.GetComponent<Bullet>().setValues(damage);
        origin.GetComponent<bossControler>().abilityFinish();
    }
}
