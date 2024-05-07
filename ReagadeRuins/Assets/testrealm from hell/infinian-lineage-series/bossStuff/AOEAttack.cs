using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AOEAttack : MonoBehaviour
{
    public float maxArea;
    public float castDuration;
    public float maxCastDuraiton;
    float calucations;
    bool hasfinished = false;

    public float range;
    private void Start()
    {
        castDuration = maxCastDuraiton;
    }
    private void OnEnable()
    {
        castDuration = maxCastDuraiton;

    }

    private void FixedUpdate()
    {
        if (!hasfinished)
        {
            castDuration -= Time.deltaTime;
            calucations = maxArea * ((maxCastDuraiton - castDuration) / maxCastDuraiton);
            this.transform.GetChild(0).transform.localScale = new Vector3(calucations, this.transform.GetChild(0).transform.localScale.y, this.transform.GetChild(0).transform.localScale.z);
        }
        if (castDuration <= 0)
        {
            transform.GetComponent<BoxCollider>().enabled = true;
            hasfinished = true;
            this.transform.GetChild(0).transform.localScale = new Vector3(maxArea, this.transform.GetChild(0).transform.localScale.y, this.transform.GetChild(0).transform.localScale.z);
        }

    }

    /*public void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            collision.gameObject.GetComponent<AttributeManager>().TakeDamage(transform.parent.GetComponent<bossControler>().attacks[transform.parent.GetComponent<bossControler>().abilityQued].damage);
            transform.GetComponent<BoxCollider>().enabled = false;
        }
    }*/
    private void OnTriggerStay(Collider collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            collision.gameObject.GetComponent<AttributeManager>().TakeDamage(transform.parent.GetComponent<bossControler>().attacks[transform.parent.GetComponent<bossControler>().abilityQued].damage);
            transform.GetComponent<BoxCollider>().enabled = false;
        }
    }
}
