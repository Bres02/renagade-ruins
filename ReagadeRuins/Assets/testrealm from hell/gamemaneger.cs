using System.Collections;
using System.Collections.Generic;
using UnityEditor.SearchService;
using UnityEngine;
using UnityEngine.SceneManagement;

public class gamemaneger : MonoBehaviour
{
    public GameObject playerRefrence;

    public GameObject[] puzzleTiles;
    public persistdata persistdata;

    private void Awake()
    {
        playerRefrence.GetComponent<AttributeManager>().health = persistdata.currentHealth;
    }
    private void Update()
    {
        
    }
    public void setStats()
    {
        persistdata.currentHealth = persistdata.maxHealth;
        persistdata.currentScene = -1;
        persistdata.pickScenes[0] = Random.Range(1,4);
        persistdata.pickScenes[1] = Random.Range(1, 4);
    }
    public void Exit()
    {

    }

    public void loadNext()
    {
        persistdata.currentHealth = playerRefrence.GetComponent<AttributeManager>().health;
        persistdata.currentScene++;
        SceneManager.LoadScene(persistdata.currentScene);
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
