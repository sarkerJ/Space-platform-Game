using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rocketLaunch : MonoBehaviour //added this myself
{
    Rigidbody2D myRB;
    public float launchGravity;

    // Start is called before the first frame update
    void Start()
    {
        myRB = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag == "Player")
        {
            playerHealth player = other.GetComponent<playerHealth>();
            player.winGame();
            transform.GetChild(0).gameObject.SetActive(true);

            myRB.gravityScale = launchGravity;
            
        }
    }
}
