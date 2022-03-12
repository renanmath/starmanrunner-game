using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Parallax : MonoBehaviour
{
    public Transform cam;
    public float parallaxSpeed;
    
    private float startPosition;
    private float lengh;
    

    void Start()
    {
        startPosition = transform.position.x;
        lengh = GetComponent<SpriteRenderer>().bounds.size.x;
    }

    void Update()
    {
        float reposition = cam.position.x*(1- parallaxSpeed);
        float distance = cam.position.x*parallaxSpeed;
        transform.position = new Vector3(startPosition+distance, transform.position.y, transform.position.z);

        if(reposition > startPosition + lengh)
        {
            startPosition += lengh;
        }
    }
}
