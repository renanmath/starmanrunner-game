using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    public int demageApplied;
    public GameObject explosionPrefab;
    private Rigidbody2D rigBullet;
    private float bulletSpeed = 70f;

    void Start()
    {
        rigBullet = GetComponent<Rigidbody2D>();
    }


    void FixedUpdate()
    {
        rigBullet.velocity = new Vector2(bulletSpeed, rigBullet.velocity.y);
    }

    void OnCollisionEnter2D(Collision2D col)
    {
        GameObject explosion = Instantiate(explosionPrefab, transform.position, transform.rotation);
        Destroy(gameObject, 0.1f);
        Destroy(explosion, 0.3f);
    }
}
