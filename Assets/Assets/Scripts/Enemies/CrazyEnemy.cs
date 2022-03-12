using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrazyEnemy : EnemyBase
{
    private float referenceVelocity = 3f;
    private float xVelocityVariation = 5f;
    private float yVelocityVariation = 5f;
    private Rigidbody2D rigEnemy;
    

    void Start()
    {
        rigEnemy = GetComponent<Rigidbody2D>();
        Destroy(gameObject, 20f);
        life = 6;
        scoreToIncrease = 25;
        demageOnPlayer = -5;
    }

  
    void LateUpdate()
    {
        float xRandom = Random.Range(-xVelocityVariation,xVelocityVariation);
        float yRandom = Random.Range(-yVelocityVariation,yVelocityVariation);
        rigEnemy.velocity = new Vector2(-referenceVelocity+xRandom, yRandom);
        float yPositionVariation = Random.Range(-0.5f, 0.5f);
        rigEnemy.position = new Vector2(rigEnemy.position.x, rigEnemy.position.y +yPositionVariation);
    }

}
