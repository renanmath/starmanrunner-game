using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class SpawnPlataform : MonoBehaviour
{
    public List<GameObject> allPlatforms = new List<GameObject>();
    private List<GameObject> currentPlatforms = new List<GameObject>();
    private Transform player;
    private int currentPlatformIndex;
    private float offset;
    private float finalPointReference;
    private float yPosition;
    private int platformsCounter;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        offset = 0;
        finalPointReference = 25f;
        yPosition = 1.2f;

        for(int i=0; i < 3; i++)
         {
            GameObject pt = Instantiate(allPlatforms[i], new Vector2(25*platformsCounter,yPosition), transform.rotation);
            Destroy(pt, 30f);
            currentPlatforms.Add(pt);
            offset += 25f;
            platformsCounter ++;

        }        
   
    }

    void callNewPlatform()
    {
        int randomIndex = Random.Range(0, allPlatforms.Count);
        GameObject newPlatform = Instantiate(allPlatforms[randomIndex], new Vector2(25*platformsCounter,yPosition), transform.rotation);
        Destroy(newPlatform, 60f);
        offset +=25f;
        platformsCounter ++;

    }

    void Update()
    {
        checkIfPassFinalPoint();
    }


     private void checkIfPassFinalPoint()
  {
        float distance = finalPointReference - player.position.x;
        if(distance < 1f)
        {        
             finalPointReference += 25f;
             callNewPlatform();
            
         }
     }

}






// public class SpawnPlataform : MonoBehaviour
// {
//     public List<GameObject> platforms = new List<GameObject>();
//     private List<Transform> currentPlatforms = new List<Transform>();
//     private Transform player;
//     private Transform currentPlatformPoint;
//     private int currentPlatformIndex;
//     private float offset;
//     private float finalPointReference;
//     private float yPosition;
    
//     void Start()
//     {
//         player = GameObject.FindGameObjectWithTag("Player").transform;
//         offset = 0;
//         finalPointReference = 25f;
//         yPosition = 1.2f;

//         for(int i=0; i < platforms.Count; i++)
//         {
//             Transform pt = Instantiate(platforms[i], new Vector2(25*i,yPosition), transform.rotation).transform;
//             currentPlatforms.Add(pt);
//             offset += 25f;

//         }     
        
//     }
    
//     void Update()
//     {
//         checkIfPassFinalPoint();
//     }

//     private void Recycle(GameObject platform)
//     {
//         platform.transform.position = new Vector2(offset, yPosition);
//         offset += 25f;
        
//     }

//     private void checkIfPassFinalPoint()
//     {
//         float distance = finalPointReference - player.position.x;
//         if(distance < 1f)
//         {        
//             finalPointReference += 25f;
//             Recycle(currentPlatforms[currentPlatformIndex].gameObject);
//             currentPlatformIndex = (currentPlatformIndex+1)%(currentPlatforms.Count);
//         }
//     }

// }
