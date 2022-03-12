using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinalPoint : MonoBehaviour
{
    void Start()
    {
        transform.position = new Vector3(transform.position.x, 1.2f, transform.position.z);
    }
}