using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlyingEnemy : EnemyBase
{
    public float enemySpeed;
    private Rigidbody2D rigEnemy;
    private float yVelocityVariation;

    void Start()
    {   
        enemySpeed = 5f;
        rigEnemy = GetComponent<Rigidbody2D>();
        Destroy(gameObject, 20f);
        yVelocityVariation = 10f;
        life = 20;
        scoreToIncrease = 5;
        demageOnPlayer = 15;
    }

    
    void LateUpdate()
    {
       
        rigEnemy.velocity = new Vector2(-enemySpeed, Random.Range(-yVelocityVariation, yVelocityVariation));
        enemySpeed = Random.Range(1f, 3f);
    }

}
