using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bossGravityTrigger : MonoBehaviour //added this myself
{
    Rigidbody2D enemyRB;
    float goUpTime = 3f;
    float goUpNow = 0f;
    public float gravityAfterTrigger;
    float currentScale;

    // Start is called before the first frame update
    void Start()
    {
        enemyRB = GetComponent<Rigidbody2D>();
       currentScale = enemyRB.gravityScale;
    }

    // Update is called once per frame
    void Update()
    {
        if (Time.time > goUpNow)
        {
            if (Random.Range(0, 10) >= 3) goUPMethod();
            goUpNow = Time.time + goUpTime;

        }
        else
        {
            enemyRB.gravityScale = currentScale;
        }
    }

    void goUPMethod()
    {
        
        enemyRB.gravityScale = gravityAfterTrigger;

    }

}
