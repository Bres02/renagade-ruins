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
            hasfinished = true;
            this.transform.GetChild(0).transform.localScale = new Vector3(maxArea, this.transform.GetChild(0).transform.localScale.y, this.transform.GetChild(0).transform.localScale.z);
        }

    }




    private void OnDrawGizmos()
    {
        //Shows the radius as a white circle
        Gizmos.color = Color.blue;
        UnityEditor.Handles.DrawWireDisc(transform.position, new Vector3(0, 1, 0), range);


    }
}
