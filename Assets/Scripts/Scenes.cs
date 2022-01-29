using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Scenes : MonoBehaviour
{

   
    // Start is called before the first frame update
    void Start()
    {


    
        
    }

    // Update is called once per frame

    

    void Update()
    {

        if(Input.GetKeyDown(KeyCode.S))
        {
            
           SceneManager.LoadScene("Gameplay", LoadSceneMode.Single);

        }

        if(Input.GetKeyDown(KeyCode.J)){
            SceneManager.LoadScene("Statistics", LoadSceneMode.Single);
            //run Stats stuff
        }

        
 
    }

    
    


}
