using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainScene : MonoBehaviour
{
    public GameObject background;
    public Vector3 starting;

    void Start()
    {
        starting = background.transform.position;
        Vector3 posBefore = background.transform.position;
        background.transform.position = new Vector3(posBefore.x, posBefore.y, posBefore.z);
    }

    void Update()
    {
        Vector3 posBefore = background.transform.position;
        background.transform.position = new Vector3(posBefore.x, posBefore.y, posBefore.z + 0.03f);

        if (posBefore.z > 0.31)
        {
            background.transform.position = new Vector3(starting.x, starting.y, starting.z);
        }
    }

}
