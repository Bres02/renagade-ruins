using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyspawner : MonoBehaviour
{
    [SerializeField] private GameObject enemy;
    [SerializeField] private gamemaneger gamemaneger;
    
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(EnemySpawning());

    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private IEnumerator EnemySpawning()
    {
        float delay = 5.0f;
        WaitForSeconds wait = new WaitForSeconds(delay);

        while (true)
        {
            yield return wait;
            GameObject newEnemy = Instantiate(enemy);
            newEnemy.GetComponent<SpiderEnemy>().setinfo(gamemaneger);
        }
    }
}
