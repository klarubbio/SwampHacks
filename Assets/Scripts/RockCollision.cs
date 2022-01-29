using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RockCollision : MonoBehaviour
{
    void OnTriggerEnter(Collider other)
    {
        Debug.Log("collided");
        transform.position = new Vector3(5.0f, 0.0f, -3.0f);
    }
}
