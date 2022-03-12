using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnItem : MonoBehaviour
{
    public static SpawnItem instance;
    public List<GameObject> itensList = new List<GameObject>();
    private double gameScore;
    private double randomControl;
    private int numberItensSpawned;

   

    void Start()
    {
       randomControl = Random.Range(5,7);
       Vector3 newPosition = new Vector3(transform.position.x + 120f, transform.position.y, transform.position.z);
       Instantiate(itensList[1], newPosition, transform.rotation);
       spawnHeart();
        instance = this;
       
    
    }

    void LateUpdate()
    {
        gameScore = GameManeger.instance.score;

        if(gameScore > randomControl)
        {
            // the bullet item (increase ammunition)
            spawnBulletItem();
            
            
        }

        if(numberItensSpawned > 2)
        {
            // the flying item (to enter fly mode)
            spawnFlyingItem();

        }
    }

    public void spawnHeart()
    {
        // Spwan the heart icon (it heal life when trigged)
        float xRandom = Random.Range(10f, 50f);
        Vector3 spawnPosition = new Vector3(transform.position.x + xRandom, transform.position.y, transform.position.z);
        GameObject newHeart = Instantiate(itensList[2], spawnPosition, transform.rotation);
        Destroy(newHeart, 60f);
    }

    public void spawnFlyingItem()
    {
        numberItensSpawned = 0;
        float xRandom = Random.Range(60f, 120f);
        float yRandom =  Random.Range(0f, 1.5f);
        Vector3 spawnPosition = new Vector3(transform.position.x + xRandom, transform.position.y + yRandom, transform.position.z);
        GameObject newItem = Instantiate(itensList[1], spawnPosition, transform.rotation);
    }

    public void spawnBulletItem()
    {
        GameObject newItem = Instantiate(itensList[0], transform.position, transform.rotation);
        Destroy(newItem, 15f);
        randomControl = gameScore + Random.Range(42, 108);
        numberItensSpawned ++;
    }

    
}
