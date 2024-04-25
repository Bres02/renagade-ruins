using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AOEAttack : MonoBehaviour
{
    public GameObject AOEArea;
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


    // Update is called once per frame
    void Update()
    {
        

    }

    private void FixedUpdate()
    {
        if (!hasfinished)
        {
            castDuration -= Time.deltaTime;
            calucations = maxArea * ((maxCastDuraiton - castDuration) / maxCastDuraiton);
            AOEArea.transform.GetChild(0).transform.localScale = new Vector3(calucations, AOEArea.transform.GetChild(0).transform.localScale.y, AOEArea.transform.GetChild(0).transform.localScale.z);
        }
        if (castDuration <= 0)
        {
            hasfinished = true;
            AOEArea.transform.GetChild(0).transform.localScale = new Vector3(maxArea, AOEArea.transform.GetChild(0).transform.localScale.y, AOEArea.transform.GetChild(0).transform.localScale.z);
        }

    }




    private void OnDrawGizmos()
    {
        //Shows the radius as a white circle
        Gizmos.color = Color.blue;
        UnityEditor.Handles.DrawWireDisc(transform.position, new Vector3(0, 1, 0), range);


    }
}
