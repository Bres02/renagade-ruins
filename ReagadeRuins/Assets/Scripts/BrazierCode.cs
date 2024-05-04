using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class BrazierCode : MonoBehaviour
{
    // The fire to use for the brazier activation
    [SerializeField] private GameObject fire;

    // Determines if the brazier is already on or not
    private bool on;

    Vector3 firePosition;


    // When the object is initialized, make sure that the flame is off
    private void Start()
    {
        on = false;
    }

    // When the player strikes the brazier with their sword, then the brazier will light up and be set ablaze
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("sword"))
        {
            if (!on)
            {
                on = true;

                firePosition = new Vector3(this.transform.position.x, this.transform.position.y + 2, this.transform.position.z);

                Instantiate(fire, firePosition, Quaternion.identity);
            }
        }
    }
}
