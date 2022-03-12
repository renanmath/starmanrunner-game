using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollower : MonoBehaviour
{
    
    public float cameraSpeed;
    private Transform mainPlayer;

    void Start()
    {
        mainPlayer = GameObject.FindGameObjectWithTag("Player").transform;
        cameraSpeed = 50f;

    }

    // Update is called once per frame
    void LateUpdate()
    {
        Vector3 newCameraPosition = new Vector3(mainPlayer.position.x + 10f, 6.5f, transform.position.z);
        transform.position = Vector3.Slerp(transform.position, newCameraPosition, cameraSpeed*Time.deltaTime);
    }
}
