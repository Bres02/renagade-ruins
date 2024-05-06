using System.Collections;
using System.Collections.Generic;
using Unity.Burst.Intrinsics;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float speed = 10f;
    private int damage;

    private Rigidbody rb;
    void Awake()
    {
        rb = GetComponent<Rigidbody>();
        rb.velocity = transform.forward * speed;
    }
    public void setValues(int _damage)
    {
        damage = _damage;
    }
    void FixedUpdate()
    {
        rb.MovePosition(rb.position + rb.velocity * Time.fixedDeltaTime);
    }
    public void OnTriggerEnter(Collider collision)
    {
        if (this.gameObject.tag == "PlayerBullet")
        {
            if (collision.gameObject.tag == "Enemy" || collision.gameObject.tag == "Boss")
            {
                collision.gameObject.GetComponent<EnemyHealthControler>().TakeDamae(this.gameObject.GetComponent<AttributeManager>().attack);
                Destroy(this.gameObject);
            } else if (collision.gameObject.tag == "Structure")
            {
                Destroy(this.gameObject);
            }
        }
        if (collision.gameObject.tag == "Player")
        {
            collision.gameObject.GetComponent<AttributeManager>().TakeDamage(damage);
            Destroy(this.gameObject);
        } else if (collision.gameObject.tag == "Structure")
        {
            Destroy(this.gameObject);
        } 
    }
}
