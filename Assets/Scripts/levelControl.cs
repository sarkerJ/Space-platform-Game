using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class levelControl : MonoBehaviour  //added this myself
{
    public string levelName;
    public float teleportTime;
    bool teleportNow = false;
    float resetTime;

   // public Text winGameScreen;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (teleportNow == true && resetTime <= Time.time)
        {
            SceneManager.LoadScene(levelName);
        }
    }


    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
          
            teleportNow = true;
            
            resetTime = Time.time + teleportTime;
        }
    }
}
