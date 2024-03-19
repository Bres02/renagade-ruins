using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageTester : MonoBehaviour
{
    public AttributeManager playerAM;
    public AttributeManager enemyAM;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.F11))
        {
            playerAM.DealDamage(enemyAM.gameObject);
        }

        if (Input.GetKeyDown(KeyCode.F12))
        {
            enemyAM.DealDamage(playerAM.gameObject);
        }
    }
}
