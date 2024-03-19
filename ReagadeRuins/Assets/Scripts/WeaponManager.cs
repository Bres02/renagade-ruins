using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponManager : MonoBehaviour
{
    public GameObject weapon;

    public void EnableWeaponCollider(int isEnabled)
    {
        if (weapon != null)
        {
            var col = weapon.GetComponent<Collider>();

            if (col != null)
            {
                if (isEnabled == 1)
                {
                    col.enabled = true;
                } else
                {
                    col.enabled = false;
                }
            }
        }
    }
}
