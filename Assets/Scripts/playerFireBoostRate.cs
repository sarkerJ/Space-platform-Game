using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerFireBoostRate : MonoBehaviour //added this myself
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag == "Player")
        {
            playerController fireRate = other.GetComponent<playerController>();
            fireRate.increaseFireRate();

            
            Destroy(gameObject);
        }
    }
}
