using System.Collections;
using System.Collections.Generic;
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
    void OnCollisionEnter(Collision collision)
    {
        collision.gameObject.GetComponent<AttributeManager>().TakeDamage(damage);
        
    }
}
