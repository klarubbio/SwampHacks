using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GatorBehavior : MonoBehaviour
{
    public GameObject gator;
    public GameObject rock;

    private bool rockActive;

    // Start is called before the first frame update
    void Start()
    {
        //initialize obstacles to off screen position  
        rockActive = false; 
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    //generate time for next obstacle
    float NextObstacleTime()
    {
        return 0.0;
    }
}
