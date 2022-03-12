using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBase : MonoBehaviour
{
    public int life;
    public int scoreToIncrease;
    public int demageOnPlayer;

    public virtual void applyDemage(int demageValue)
    {
        life -= demageValue;

        if(life <= 0)
        {
            AudioManager.instance.playSound(AudioManager.instance.destroyEnemySound);
            Destroy(gameObject);
            SpawnItem.instance.spawnHeart();
        }
    }

    protected void OnCollisionEnter2D(Collision2D coll)
    {
        if(coll.gameObject.tag == "playerBullet")
        {
            applyDemage(coll.gameObject.GetComponent<Projectile>().demageApplied);
            AudioManager.instance.playSound(AudioManager.instance.hitEnemySound);
            GameManeger.instance.increaseScore(scoreToIncrease);
        }

        if(coll.gameObject.tag == "Player")
        {
            MainPlayer.instance.receiveDemage(demageOnPlayer);
            SpawnItem.instance.spawnHeart();
        }
    }
    
}
