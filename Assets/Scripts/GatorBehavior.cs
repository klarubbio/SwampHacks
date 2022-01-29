using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GatorBehavior : MonoBehaviour
{
    public GameObject gator;
    public GameObject rock;

    private bool rockActive;
    private bool gatorJump;
    private float jumpTime;
    private Vector3 jumpHeight;
    private float nextObstacleTime; //set to -1 after obstacle is deployed

    // Start is called before the first frame update
    void Start()
    {
        //initialize obstacles to off screen position  
        rockActive = false;
        gatorJump = false;
        jumpTime = -1.0f;
        jumpHeight = new Vector3(0.0f, 0.01f, 0.0f);
        nextObstacleTime = -1.0f;
        
    }

    // Update is called once per frame
    void Update()
    {
        //handle rock generation and movement
        if (nextObstacleTime == -1.0f)
            GenerateNextObstacleTime();
        else if(Time.time >= nextObstacleTime)
        {
            if (rock.transform.position.z > 3)
            {
                nextObstacleTime = -1.0f;
                rock.transform.position = new Vector3(5.1f, 0.0f, -3.0f);
            }
            //indicates collision has occured
            else if(rock.transform.position.x == 5.0f)
            {
                //player loses
                Debug.Log("you lose");
                //space to play again
                if (Input.GetKeyDown(KeyCode.Space))
                    SceneManager.LoadScene("Gameplay", LoadSceneMode.Single);
                //'s' to see statistics
            }
            else
            {
                //set rock pos until it hits gator or action is taken
                Vector3 posBefore = rock.transform.position;
                rock.transform.position = new Vector3(3, posBefore.y, posBefore.z + 0.01f);
            }
        }


        //handle jumping
        if (Input.GetKeyDown(KeyCode.Space) && !gatorJump)
        {
            Debug.Log("space pressed");
            gatorJump = true;
            jumpTime = Time.time;
        }

        //move up
        if(gatorJump && Time.time < (jumpTime + 0.5f))
        {
            gator.transform.position += jumpHeight;
        }
        //move back down
        else if(gatorJump && Time.time < (jumpTime + 1.0f))
        {
            gator.transform.position -= jumpHeight;
        }
        //reset to defaults
        else if(gatorJump && Time.time > (jumpTime + 1.0f))
        {
            gator.transform.position = new Vector3(3.0f, 0.0f, 1.75f);
            gatorJump = false;
            jumpTime = -1.0f;
        }
    }

    //generate time for next obstacle
    void GenerateNextObstacleTime()
    {
        nextObstacleTime = Time.time + Random.Range(2.0f, 5.0f);
        Debug.Log("next time:" + nextObstacleTime);
    }
}
