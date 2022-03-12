using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlyingItem : MonoBehaviour
{
    private float itemSpeed;
    private Rigidbody2D rigItem;
    private float yVelocityVariation;

    void Start()
    {   
        itemSpeed = 4f;
        rigItem = GetComponent<Rigidbody2D>();
        Destroy(gameObject, 20f);
        yVelocityVariation = 1f;
        Destroy(gameObject, 180f);

    }

    
    void LateUpdate()
    {
       
        rigItem.velocity = new Vector2(-itemSpeed, Random.Range(-yVelocityVariation, yVelocityVariation));
        //enemySpeed = Random.Range(1f, 3f);
    }

    void OnTriggerEnter2D(Collider2D coll)
    {
        if(coll.gameObject.tag == "Player")
        {
            MainPlayer.instance.beginFly();
            GameManeger.instance.increaseScore(15);
            Destroy(gameObject, 0.1f);
        }
    }

}
