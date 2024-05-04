using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class AttributeManager : MonoBehaviour
{
    public int health;
    public int attack;

    public void TakeDamage(int amount)
    {
        if (this.gameObject.tag == "Player")
        {
            if (this.gameObject.GetComponent<PlayerMovement>().isDodging)
            {
                health -= 0;
            }
        }
        else
        {
            health -= amount;
        }

        if (health <= 0)
        {
            if (this.gameObject.tag == "Player")
            {
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
            }else if(this.gameObject.tag == "Enemy")
            {
                Destroy(this.gameObject);
            }
            // TODO
            // Currently only for active scene, will need to change for starting screen/game over screen to replace.
            
        } 
    }

    public void DealDamage(GameObject target)
    {
        var am = target.GetComponent<AttributeManager>();
        if (am != null)
        {
            am.TakeDamage(attack);
        }
        
    }
}
