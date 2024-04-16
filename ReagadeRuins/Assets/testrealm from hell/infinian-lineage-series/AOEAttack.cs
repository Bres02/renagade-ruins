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
            AOEArea.transform.localScale = new Vector3(calucations, AOEArea.transform.localScale.y, AOEArea.transform.localScale.z);
        }
        if (castDuration <= 0)
        {
            hasfinished = true;
            AOEArea.transform.localScale = new Vector3(maxArea, AOEArea.transform.localScale.y, AOEArea.transform.localScale.z);
        }

    }

}
