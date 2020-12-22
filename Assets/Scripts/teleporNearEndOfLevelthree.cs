using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class teleporNearEndOfLevelthree : MonoBehaviour //added this myself
{
    public Transform teleportLocation;
    public GameObject character;
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
            other.transform.position = teleportLocation.position;
        }
    }
}
