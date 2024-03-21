using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PuzzleTile : MonoBehaviour
{

    public Material mat;
    public Material mat2;

    public gamemaneger gm;

    public bool on;

    void Start()
    {
        on = false;
    }

    // Changes color of tile if player comes into contact with the tile
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            if (!on)
            {
                this.GetComponent<Renderer>().material = mat2;

                on = true;
            } else
            {
                this.GetComponent<Renderer>().material = mat;

                on = false;
            }

            TileTrigger();
        }
    }

    public void TileTrigger()
    {
        gm.CheckTiles();
    }
}
