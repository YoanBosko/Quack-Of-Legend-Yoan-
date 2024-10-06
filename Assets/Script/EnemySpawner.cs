using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public GameObject Enemy1;
    void Start()
    {
        InvokeRepeating("SpawnEnemy", 0f, 2f);
    }

    // Update is called once per frame
    void Update()
    {

    }

    void SpawnEnemy()
    {
        Vector2 min = Camera.main.ViewportToWorldPoint(new Vector2(-0.1f, -0.1f));
        Vector2 max = Camera.main.ViewportToWorldPoint(new Vector2(1.1f, 1.1f));
        
        GameObject enemy = Instantiate(Enemy1);

        switch (Random.Range(1, 5))
        {
            case 1:
                enemy.transform.position = new Vector2(max.x, Random.Range(min.y, max.y));
                break;
            case 2:
                enemy.transform.position = new Vector2(min.x, Random.Range(min.y, max.y));
                break;
            case 3:
                enemy.transform.position = new Vector2(Random.Range(min.x, max.x), max.y);
                break;
            case 4:
                enemy.transform.position = new Vector2(Random.Range(min.x, max.x), min.y);
                break;
        }

    }
}
