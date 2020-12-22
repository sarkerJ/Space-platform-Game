﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class projectileController : MonoBehaviour
{
    public float rocketSpeed;
    Rigidbody2D myRB;


    // Start is called before the first frame update
    void Awake()
    {
        myRB = GetComponent<Rigidbody2D>();
        if(transform.localRotation.z>0)
            myRB.AddForce(new Vector2(-1, 0)*rocketSpeed,ForceMode2D.Impulse);  // (when z is greater ) meaning ur facing left so rocket should fly left
        else 
            myRB.AddForce(new Vector2(1, 0) * rocketSpeed, ForceMode2D.Impulse); //else rocket should fly right

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void removeForce()
    {
        myRB.velocity = new Vector2(0, 0);

    }
}
