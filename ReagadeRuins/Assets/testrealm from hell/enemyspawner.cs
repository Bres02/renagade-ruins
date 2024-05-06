using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyspawner : MonoBehaviour
{
    [SerializeField] private GameObject enemy;
    [SerializeField] private gamemaneger gamemaneger;

    public bool active = true;
    
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(EnemySpawning());

    }

    
    private IEnumerator EnemySpawning()
    {
        float delay = 5.0f;
        WaitForSeconds wait = new WaitForSeconds(delay);

        while (active)
        {
            yield return wait;
            GameObject newEnemy = Instantiate(enemy, this.transform);
            newEnemy.GetComponent<SpiderEnemy>().setinfo(gamemaneger);
            gamemaneger.addEnemie();
        }
    }
}
