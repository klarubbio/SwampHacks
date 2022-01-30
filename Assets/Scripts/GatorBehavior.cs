using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
using UnityEngine.UI;


public class GatorBehavior : MonoBehaviour
{
    public GameObject gator;
    public GameObject rock;
    public TextMeshPro endText;
    public Sprite gatorSwim1;
    public Sprite gatorSwim2;
    public Sprite gatorJumping;
    public Sprite gatorDead;
    public Canvas results;

    private bool rockActive;
    private bool gatorJump;
    private float jumpTime;
    private Vector3 jumpHeight;
    private float nextObstacleTime; //set to -1 after obstacle is deployed
    private bool statsReported;
    private int score;
    private SpriteRenderer render;
    private float switchSprite;
    private bool swim1;
    private bool gatorDeath;



    // Start is called before the first frame update
    void Start()
    {
        //initialize obstacles to off screen position  
        rockActive = false;
        gatorJump = false;
        jumpTime = -1.0f;
        jumpHeight = new Vector3(0.0f, 0.01f, 0.0f);
        nextObstacleTime = -1.0f;
        statsReported = false;
        score = 0;
        endText.gameObject.GetComponent<Renderer>().enabled = false;
        render = gator.GetComponent<SpriteRenderer>();
        switchSprite = 0.2f;
        swim1 = true;
        gatorDeath = false;
        results.GetComponent<Canvas>().enabled = false;
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
                score += 10;
                nextObstacleTime = -1.0f;
                rock.transform.position = new Vector3(5.1f, -0.2f, -3.0f);
            }
            //indicates collision has occured
            else if(rock.transform.position.x == 5.0f)
            {
                //report game stats
                if (!statsReported)
                {
                    gatorDeath = true;
                    GetComponent<StatisticsWriting>().End(score);
                    endText.gameObject.GetComponent<Renderer>().enabled = true;
                    endText.SetText(score.ToString());
                    Debug.Log(score);
                    statsReported = true;
                    results.GetComponent<Canvas>().enabled = true;
                }
                //space to play again
                if (Input.GetKeyDown(KeyCode.Space))
                    SceneManager.LoadScene("Gameplay", LoadSceneMode.Single);
                //s to see statistics
                if (Input.GetKeyDown(KeyCode.S))
                    SceneManager.LoadScene("Statistics", LoadSceneMode.Single);
                
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


        if (gatorDeath)
            render.sprite = gatorDead;
        else if (gatorJump)
            render.sprite = gatorJumping;
        else if (Time.time >= switchSprite && swim1)
        {
            render.sprite = gatorSwim2;
            swim1 = false;
            switchSprite += 0.2f;
        }
        else if (Time.time >= switchSprite && !swim1)
        {
            render.sprite = gatorSwim1;
            swim1 = true;
            switchSprite += 0.2f;
        }


    }

    //generate time for next obstacle
    void GenerateNextObstacleTime()
    {
        nextObstacleTime = Time.time + Random.Range(2.0f, 5.0f);
        Debug.Log("next time:" + nextObstacleTime);
    }
}

