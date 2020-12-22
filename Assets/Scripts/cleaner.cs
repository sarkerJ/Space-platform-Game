using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cleaner : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
     void OnTriggerEnter2D(Collider2D other) //added this myself
    {
        if (other.tag == "Player")
        {
            playerHealth playerFell = other.GetComponent<playerHealth>();
            playerFell.addDamage(40);
        }
        else
        {
            if (other.gameObject.layer == LayerMask.NameToLayer("drop")) //included this top bit of if myself
            {
                Destroy(other.gameObject);
            }
            else
            { //from video
                enemyHealth enemyFell = other.GetComponentInChildren<enemyHealth>();
                enemyFell.makeDead();
            }
        }
              

    }
}
