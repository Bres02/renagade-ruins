using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float speed = 10f;
    public AttributeManager atm;
    private int damage;

    private Rigidbody rb;
    void Awake()
    {
        rb = GetComponent<Rigidbody>();
        rb.velocity = transform.forward * speed;

        damage = atm.attack;
    }
    void FixedUpdate()
    {
        rb.MovePosition(rb.position + rb.velocity * Time.fixedDeltaTime);
    }
    void OnCollisionEnter(Collision collision)
    {
        collision.gameObject.GetComponent<AttributeManager>().TakeDamage(damage);
        
    }
}
