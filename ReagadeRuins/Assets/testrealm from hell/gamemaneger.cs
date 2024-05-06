using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEditor.SearchService;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class gamemaneger : MonoBehaviour
{
    public GameObject playerRefrence;

    public GameObject[] puzzleTiles;
    public persistdata persistdata;
    public bool puzzleComplete = false;

    public GameObject[] spawners;
    public int maxEnemies;
    public int numSpawned;

    public TMP_Text enemiesLeft;
    public int enemiesLeftNum;
    public TMP_Text tilesLeft;
    public int tilesLeftNum;

    private void Awake()
    {
        tilesLeftNum = puzzleTiles.Length;
        if (maxEnemies<10000)
        {
            enemiesLeftNum = maxEnemies;
        }
        if (persistdata.currentHealth >0 && playerRefrence != null)
        {
            playerRefrence.GetComponent<AttributeManager>().health = persistdata.currentHealth;
        }
        if(tilesLeftNum>0)
        {
            tilesLeft.text = (tilesLeftNum).ToString();
        }
        if (enemiesLeft != null)
        {
            enemiesLeft.text = enemiesLeftNum.ToString();
        }

    }
    private void Update()
    {
        if (puzzleComplete && enemiesLeftNum == 0)
        {
            loadNext();
        }
    }
    public void setStats()
    {
        persistdata.currentHealth = persistdata.maxHealth;
        persistdata.currentScene = 0;
        persistdata.pickScenes[0] = Random.Range(1,5);
        persistdata.pickScenes[1] = Random.Range(1, 5);
    }
    public void Exit()
    {
        Debug.Log("exit");
    }

    public void loadNext()
    {
        Debug.Log(persistdata.currentScene);
        if (playerRefrence !=null)
        {
            persistdata.currentHealth = playerRefrence.GetComponent<AttributeManager>().health;
        }
        persistdata.currentScene++;
        SceneManager.LoadScene(persistdata.pickScenes[persistdata.currentScene]);
    }
    public void addEnemie()
    {
        if (maxEnemies < 10000)
        {
            numSpawned++;
            enemiesLeft.text = enemiesLeftNum.ToString();
            if (numSpawned >= maxEnemies && spawners.Length != 0)
            {
                stopSpawners();
            }
        }
        else
        {
            enemiesLeftNum++;
            enemiesLeft.text = enemiesLeftNum.ToString();
        }
    }
    public void RemoveEnemie()
    {
        enemiesLeftNum--;
        enemiesLeft.text = enemiesLeftNum.ToString();
        if ((maxEnemies < 10000 || puzzleComplete) && enemiesLeftNum <= 0)
        {
            loadNext();
        }
    }
    public void stopSpawners()
    {
        for (int i = 0; i < spawners.Length; i++)
        {
            spawners[i].GetComponent<enemyspawner>().enabled=false;
        }
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
        tilesLeft.text = (tilesLeftNum-x).ToString();
        if (x == puzzleTiles.Length) 
        {   
            //UnityEditor.EditorApplication.isPlaying = false;
            puzzleComplete = true;
            stopSpawners();
        }
    }
}
