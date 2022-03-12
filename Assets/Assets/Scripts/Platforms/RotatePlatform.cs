using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotatePlatform : MonoBehaviour
{
    private float initialRotation;
    private float rotationSign = 1f;
    private float maxRotation = 20f;
    private float incrementFactor = 50f;
    private float smooth = 500f;
    private float increment;
    
    void Start()
    {
        initialRotation = Random.Range(5f, 300f);

    }

    // Update is called once per frame
    void LateUpdate()
    {
        increment = increment + rotationSign*incrementFactor*Time.deltaTime;

        if (absoluteValue(increment) > maxRotation)
        {
            rotationSign = -rotationSign;
        }
        Quaternion target = Quaternion.Euler(0, 0, increment);
        transform.rotation = Quaternion.Slerp(transform.rotation, target,  Time.deltaTime * smooth);

    }

    float absoluteValue(float value)
    {
        if (value < 0) return -value;
        else return value;
    }
}
