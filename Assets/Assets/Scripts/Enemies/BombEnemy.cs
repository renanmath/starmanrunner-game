using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BombEnemy : EnemyBase
{
    public GameObject bomb;
    public Transform firePoint;
    private float thrownTime;
    private float thrownCount;

    void Start()
    {
         life = 6;
         scoreToIncrease = 5;
         demageOnPlayer = 10;
    }

    // Update is called once per frame
    void LateUpdate()
    {
        thrownTime += Time.deltaTime;

        if(thrownTime > thrownCount)
        {
            thrownTime = 0f;
            thrownCount = Random.Range(2.5f, 6.5f);
            Instantiate(bomb, firePoint.position, firePoint.rotation);

        }
    }

}
