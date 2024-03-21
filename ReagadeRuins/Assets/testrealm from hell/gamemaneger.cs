using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gamemaneger : MonoBehaviour
{
    public GameObject playerRefrence;

    public GameObject[] puzzleTiles;


    // Update is called once per frame
    void Update()
    {
        
    }

    public void CheckTiles()
    {
        int x = 0;

        for (int i = 0; i < puzzleTiles.Length; i++)
        {
            if (puzzleTiles[i].GetComponent<PuzzleTile>().on)
            {
                x += 1;
            }
        }

        

        if (x == puzzleTiles.Length) 
        {
            Debug.Log(puzzleTiles.Length);

            Debug.Log(x);
            
            UnityEditor.EditorApplication.isPlaying = false;
        }
    }
}
