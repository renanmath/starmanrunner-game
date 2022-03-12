using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnEnemies : MonoBehaviour
{
    
    public List<GameObject> enemiesList = new List<GameObject>();
    private float timeCount;
    private float spawnTime;
    private int spawnIndex;

    void Start()
    {
        spawnTime = 5f;
    }


    void Update()
    {
        timeCount += Time.deltaTime;

        if(timeCount > spawnTime)
        {
            timeCount = 0f;
            spawnTime = Random.Range(2f, 12f);
            spawnEnemy();
        }
        
    }

    void spawnEnemy()
    {
        Instantiate(enemiesList[spawnIndex], transform.position + new Vector3(0f, Random.Range(-0.5f,1f), 0), enemiesList[spawnIndex].transform.rotation);
        spawnIndex = (spawnIndex + 1)%2;
    }

}
