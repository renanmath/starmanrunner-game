using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletIcon : MonoBehaviour
{
    private int randomIncrease;
    private float signDirection =1f;
    private float iconSpeed;
    private float timeIncrement;
    private Rigidbody2D rigIcon;

    void Start()
    {
        randomIncrease = 5*Random.Range(5,10);
        rigIcon = GetComponent<Rigidbody2D>();
        iconSpeed =3f;
    }

    
    void LateUpdate()
    {
        
       rigIcon.velocity =  new Vector2(rigIcon.velocity.x, iconSpeed*signDirection);
        if(transform.position.y > 10f)
        {
            signDirection = -1f;

        }
        if(transform.position.y < 3f)
        {
            signDirection = 1f;
        }
    }
 
    
    private void OnTriggerEnter2D(Collider2D coll)
    {
        if (coll.gameObject.tag == "Player")
        {
           MainPlayer.instance.increaseAmmunition(randomIncrease);
           AudioManager.instance.playSound(AudioManager.instance.catchAmmutionSound);
           GameManeger.instance.increaseScore(15);
           Destroy(gameObject);
   
        }
    }

  
}
