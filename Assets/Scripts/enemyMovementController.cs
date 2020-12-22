﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyMovementController : MonoBehaviour
{
    public float enemySpeed;

    Animator enemyAnimator;

    //facing
    public GameObject enemyGraphic;
    bool canFlip = true;
    bool facingRight = false;
    float flipTime = 5f;
    float nextFlipChance = 0f;

    //attacking
    public float chargeTime;
    float startChargeTime;
    bool charging;
    Rigidbody2D enemyRB;

    // Start is called before the first frame update
    void Start()
    {
        enemyAnimator = GetComponentInChildren<Animator>();
        enemyRB = GetComponent<Rigidbody2D>();       
    }

    // Update is called once per frame
    void Update()
    {
        if(Time.time > nextFlipChance)
        {
            if (Random.Range(0, 10) >= 5) flipFacing();
            nextFlipChance = Time.time + flipTime;

        }
    }

     void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag == "Player")
        {
            if (facingRight && other.transform.position.x < transform.position.x)
            {
                flipFacing();
            }else if (!facingRight && other.transform.position.x > transform.position.x)
            {
                flipFacing();
            }
            canFlip = false;
            charging = true;
            startChargeTime = Time.time + chargeTime;
        }
    }

     void OnTriggerStay2D(Collider2D other)
    {
        if(other.tag == "Player"){
            if(startChargeTime < Time.time){
                if (!facingRight) enemyRB.AddForce(new Vector2(-1, 0) * enemySpeed); //moving the player to the direction the enemy is going
                else enemyRB.AddForce(new Vector2(1, 0) * enemySpeed);
                enemyAnimator.SetBool("isCharging", charging);                       //updating the animator bool so the animator works 
            }
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            canFlip = true;
            charging = false;
            enemyRB.velocity = new Vector2(0f, 0f);
            enemyAnimator.SetBool("isCharging", charging);// changing animator 
        }
    }

    void flipFacing()
    {
        if (!canFlip) return;                                      //if you cant flip don't do anything
        float facingX = enemyGraphic.transform.localScale.x;       //finding which direction it is facing
        facingX *= -1f;                                            //whatever state it was in, it now becomes the opposite
        enemyGraphic.transform.localScale = new Vector3(facingX, enemyGraphic.transform.localScale.y, enemyGraphic.transform.localScale.z);
        facingRight = !facingRight;
    }
}
