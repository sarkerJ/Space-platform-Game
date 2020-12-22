using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class laserHit : MonoBehaviour
{
    laserController myPC;
    public float laserDamage;
    public float pushBackForce;

    // Start is called before the first frame update
    void Awake()
    {
        myPC = GetComponentInParent<laserController>();

    }

    // Update is called once per frame
    void Update()
    {
        
    }


    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.layer == LayerMask.NameToLayer("Protective")) //i added this myself
        {
            myPC.removeForce();
            Destroy(gameObject);
        }
        else if (other.tag == "Player")
        {
            myPC.removeForce();
            pushBack(other.transform);
            Destroy(gameObject);
            playerHealth thePlayerHealth = other.gameObject.GetComponent<playerHealth>(); //finding the player object "playerHealth" script 
            thePlayerHealth.addDamage(laserDamage);
        }

    }

    private void OnTriggerStay2D(Collider2D other)
    {
        if (other.gameObject.layer == LayerMask.NameToLayer("Protective"))  //added this myself
        {
            myPC.removeForce();
            Destroy(gameObject);
        }
        else if (other.tag == "Player") 
        {
            myPC.removeForce();
            pushBack(other.transform);
            Destroy(gameObject);
            playerHealth thePlayerHealth = other.gameObject.GetComponent<playerHealth>(); //finding the player object "playerHealth" script 
            thePlayerHealth.addDamage(laserDamage);
        }
    }

    void pushBack(Transform pushedObject)
    {
        Vector2 pushDirection = new Vector2(0, pushedObject.position.y - transform.position.y).normalized; //the vector direction directly opposite y direction of the object pushing , normalise means make it a value between 0 and 1
        pushDirection *= pushBackForce;

        Rigidbody2D pushRB = pushedObject.gameObject.GetComponent<Rigidbody2D>(); //finding the rigidbody of the pushed object

        pushRB.velocity = Vector2.zero; //any velocity the that pushed object initially had are turned to zero (fully loses any movement)
        pushRB.AddForce(pushDirection, ForceMode2D.Impulse); // adding an immediate explosive force push direction to that game object

    }
}
