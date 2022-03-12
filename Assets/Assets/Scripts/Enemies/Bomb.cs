using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bomb : MonoBehaviour
{
    private Rigidbody2D rigBomb;
    private float xForceComponent = 5f;
    private float yForceComponent = 10f;

    void Start()
    {
        rigBomb = GetComponent<Rigidbody2D>();
        Destroy(gameObject, 20f);
        rigBomb.AddForce(new Vector2(-xForceComponent,yForceComponent), ForceMode2D.Impulse);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
