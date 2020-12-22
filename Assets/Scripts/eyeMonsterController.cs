using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class eyeMonsterController : MonoBehaviour
{

    //facing
    public GameObject enemyGraphic;
    bool canFlip = true;
    bool facingRight = false;
    float flipTime = 3f;
    float nextFlipChance = 0f;


    //Shooting
    public GameObject theProjectile;
    public float shootTime;
    public int chanceShoot;
    public Transform shootFrom;


    float nextShootTime;

    // Start is called before the first frame update
    void Start()
    {
        nextShootTime = 0f;
    }

    // Update is called once per frame
    void Update()
    {
        if (Time.time > nextFlipChance)
        {
            if (Random.Range(0, 10) >= 1) flipFacing();
            nextFlipChance = Time.time + flipTime;

        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            if (facingRight && other.transform.position.x < transform.position.x)
            {
                flipFacing();

            }
            else if (!facingRight && other.transform.position.x > transform.position.x)
            {
                flipFacing();
            }
            canFlip = false;
        }
    }

    void OnTriggerStay2D(Collider2D other)
    {
        if (other.tag == "Player" && nextShootTime < Time.time)
        {
            nextShootTime = Time.time + shootTime;
            if (Random.Range(0, 10) >= chanceShoot)
            {
                Instantiate(theProjectile, shootFrom.position, theProjectile.transform.rotation); //Quat identity means no rotation
            }
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            canFlip = true;
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
