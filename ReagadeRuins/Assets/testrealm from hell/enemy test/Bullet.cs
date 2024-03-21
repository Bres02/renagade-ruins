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
    public void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            collision.gameObject.GetComponent<AttributeManager>().TakeDamage(damage);
            Debug.Log("hit");
            Destroy(this.gameObject);
        } else if (collision.gameObject.tag == "Structure")
        {
            Destroy(this.gameObject);
        }
    }
}
