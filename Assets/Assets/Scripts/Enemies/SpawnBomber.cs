using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnBomber : MonoBehaviour
{
    public GameObject bomberPrefeb;
    public List<Transform> spawnPoints = new List<Transform>();

    void Start()
    {
        createBomber();
    }


    void Update()
    {
        
    }

    public void createBomber()
    {
        int pos = Random.Range(0, spawnPoints.Count);
        GameObject bomber = Instantiate(bomberPrefeb, spawnPoints[pos].position, spawnPoints[pos].rotation);
    }
}
