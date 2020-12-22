using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class wallController : MonoBehaviour //added this myself
{
    public GameObject wall;
    //float wallSpeed;
    float wallYValue;
    public float YvalueIncrease;
    Vector3 currentPosition;
    // Start is called before the first frame update
    void Start()
    {
        wallYValue = wall.transform.position.y + YvalueIncrease;
        currentPosition = wall.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag == "Player")
        {

            if(wall.transform.position.y < wallYValue)
            {
                wall.transform.position = new Vector3(wall.transform.position.x, wall.transform.position.y + YvalueIncrease, wall.transform.position.z);
            }
        }
    }

    private void OnTriggerStay2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
           
            while (wall.transform.position.y < wallYValue)
            {
                
                wall.transform.position = new Vector3(wall.transform.position.x, wall.transform.position.y + YvalueIncrease, wall.transform.position.z);
            }
        }
    }
    
    private void OnTriggerExit2D(Collider2D other)
    {
        if(other.tag == "Player")
        {
            
            wall.transform.position = currentPosition;
        }
    }
}
