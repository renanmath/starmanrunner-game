using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeartIcon : MonoBehaviour
{
    public void OnTriggerEnter2D(Collider2D coll)
    {
        if (coll.gameObject.tag == "Player")
        {
            MainPlayer.instance.receiveDemage(-25);
            AudioManager.instance.playSound(AudioManager.instance.catchHeartSound);
            Destroy(gameObject, 0.1f);
        }
    }
}

