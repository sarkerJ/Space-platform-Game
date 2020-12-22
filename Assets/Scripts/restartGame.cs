using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class restartGame : MonoBehaviour
{
    public float restartTime;
    bool restartNow = false;
    float resetTime;
    public string levelName;

    static bool summonTeleport = false; //added myself and the ones below
    public GameObject portal;
    public Transform portalLocation;

    //startAgain
    bool finished = false;
    string firstLevel = "levelOne";
 
    // Start is called before the first frame update
    void awake()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(restartNow == true && resetTime <= Time.time)
        {  
            if(finished == false)
            {
                SceneManager.LoadScene(levelName); //added this myself

               // print(summonTeleport);
                

            }
            else {
                //SceneManager.LoadScene(firstLevel);
                
            }

            
        }
        

    }

    public void restartTheGame()
    {
        restartNow = true;
        resetTime = Time.time+restartTime;
    }

    public void safePointPortalActive()//myself
    {
        summonTeleport = true;
        
    }

    private void OnTriggerEnter2D(Collider2D other) //added this myself
    {
        if(other.tag == "Player")
        {
            if (summonTeleport == true)
            {
                Instantiate(portal, portalLocation.position, portalLocation.rotation); //it shows up for an instance than dissapears><!!
            }
        }
    }


    public void finishTheGame()
    {
        restartNow = true;
        resetTime = Time.time + restartTime;
        finished = true;
        

    }

}
