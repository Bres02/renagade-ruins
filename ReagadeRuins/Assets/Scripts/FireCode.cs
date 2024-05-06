using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireDespawn : MonoBehaviour
{
    float delay = 2.0f;
    private int damage = 10;

    private void Start()
    {
        destroySelf();
    }


    void destroySelf()
    {
        Destroy(this.gameObject, delay);
    }

    public void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.tag == "Player" || collision.gameObject.tag == "Enemy")
        {
            collision.gameObject.GetComponent<AttributeManager>().TakeDamage(damage);
            Invoke("destroySelf", delay);
        }
    }
}
