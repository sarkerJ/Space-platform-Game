using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyDamage : MonoBehaviour
{

    public float damage;
    public float damageRate;
    public float pushBackForce;

    float nextDamage;

    // Start is called before the first frame update
    void Start()
    {
        nextDamage = 0f; //next damage to occur is at time 0

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerStay2D(Collider2D other)
    {
        if(other.tag == "Player"  && nextDamage < Time.time)
        {
            playerHealth thePlayerHealth = other.gameObject.GetComponent<playerHealth>(); //finding the player object "playerHealth" script 
            thePlayerHealth.addDamage(damage);
            nextDamage = Time.time + damageRate;

            pushBack(other.transform);
        }
    }

    void pushBack(Transform pushedObject)
    {
        Vector2 pushDirection = new Vector2 (0, pushedObject.position.y - transform.position.y).normalized; //the vector direction directly opposite y direction of the object pushing , normalise means make it a value between 0 and 1
        pushDirection *= pushBackForce;

        Rigidbody2D pushRB = pushedObject.gameObject.GetComponent<Rigidbody2D>(); //finding the rigidbody of the pushed object

        pushRB.velocity = Vector2.zero; //any velocity the that pushed object initially had are turned to zero (fully loses any movement)
        pushRB.AddForce(pushDirection, ForceMode2D.Impulse); // adding an immediate explosive force push direction to that game object
    
    }
}
