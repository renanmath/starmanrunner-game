using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VerticalTranslation : MonoBehaviour
{
    public float maxHight;
    public float minHight;

    private float objectVelocity;
    private float signDirection;
    private float randomHigthVariation;
    private Rigidbody2D rigObject;
    

    void Start()
    {
        signDirection = 1f;
        objectVelocity = 3f;
        randomHigthVariation = Random.Range(-2f, 2f);
        rigObject = GetComponent<Rigidbody2D>();
        transform.position = new Vector3(transform.position.x, transform.position.y + randomHigthVariation, transform.position.z);

    }

    // Update is called once per frame
    void FixedUpdate()
    {
        rigObject.velocity =  new Vector2(rigObject.velocity.x, objectVelocity*signDirection);
        
        if(transform.position.y > maxHight + randomHigthVariation)
        {
            signDirection = -1f;
        }

        if(transform.position.y < minHight+ randomHigthVariation)
        {
            signDirection = 1f;
        }
    }
}

