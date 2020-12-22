using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spikyTopController : MonoBehaviour //i added this myself
{
    Animator enemyAnimator;
    public GameObject enemyGraphic;
    Rigidbody2D enemyRigid;
    bool awake = true;
    private Vector3 initialPosition;
    float timeToGoUp = 4f;

    // Start is called before the first frame update
    void Start()
    {
        enemyAnimator = GetComponentInChildren<Animator>();
        enemyRigid = GetComponent<Rigidbody2D>();
        initialPosition = enemyGraphic.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag == "Player")
        {
            enemyAnimator.SetBool("isActive", awake);
            enemyRigid.gravityScale = (30f);

        }

    }
    private void OnTriggerStay2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            enemyAnimator.SetBool("isActive", awake);
            enemyRigid.gravityScale = (30f);
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        awake = false;
        enemyAnimator.SetBool("isActive", awake);
        enemyRigid.gravityScale = (0f);
       

        if (Time.time > timeToGoUp )
        {
            transform.position = initialPosition;
            timeToGoUp = Time.time + timeToGoUp;

        }

    }
}
