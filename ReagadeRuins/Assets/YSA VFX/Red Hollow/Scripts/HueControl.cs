using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HueControl : MonoBehaviour
{
    public GameObject boss;

    public float hue = 0;

    public HueValue[] hues;

    void Start()
    {
        for (int i = 0; i < hues.Length; i++)
        {
            hues[i].hue = hue;
        }
    }

    void Update()
    {
        for (int i = 0; i < hues.Length; i++)
        {
            hues[i].hue = hue;
        }
    }
    public void ended()
    {
        transform.parent.transform.parent.GetComponent<BoxCollider>().enabled = false;
        boss.GetComponent<bossControler>().abilityFinish();

    }
}
