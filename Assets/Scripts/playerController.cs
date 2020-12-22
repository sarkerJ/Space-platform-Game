using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerController : MonoBehaviour
{
    //movement variables
    public float maxSpeed;
    

    //jumping variables
    bool grounded = false;
    float groundCheckRadius = 0.2f;
    public LayerMask groundLayer;
    public Transform groundCheck;
    public float jumpHeight;


    Rigidbody2D myRB;
    Animator myAnim;
    bool facingRight;

    //for shooting
    public Transform gunTip;
    public GameObject bullet;
    float fireRate = 0.5f;
    float nextFire = 0f;

    //second shooting   //added this myself
    public bool useSecondGunTip;
    public Transform secondGunTip;
    bool boost = false;


    // Start is called before the first frame update
    void Start()
    {
        myRB = GetComponent<Rigidbody2D>();
        myAnim = GetComponent<Animator>();

        facingRight = true;
    }
    private void Update()
    {
        if(grounded && Input.GetAxis("Jump") > 0)
        {
            grounded = false;
            myAnim.SetBool("isGrounded", grounded);
            myRB.AddForce(new Vector2(0, jumpHeight));

        }


        //player shooting
        if (Input.GetAxisRaw("Fire1")>0) fireRocket();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        // check if we are grounded if no than we are falling
        grounded = Physics2D.OverlapCircle(groundCheck.position,groundCheckRadius,groundLayer);
        myAnim.SetBool("isGrounded", grounded);

        myAnim.SetFloat("verticalSpeed", myRB.velocity.y);

        float move = Input.GetAxis("Horizontal"); // unity has keys already set up for certain movements so we are using one of those
        myAnim.SetFloat("Speed", Mathf.Abs(move)); //changes the Speed Float variable we created in Animator 

        myRB.velocity = new Vector2(move * maxSpeed, myRB.velocity.y);
        

        if (move > 0 && !facingRight)
        {
            flip();
        } else if (move < 0 && facingRight)
        {
            flip();
        }
    }

    void flip()
    {
        facingRight = !facingRight;
        Vector3 theScale = transform.localScale;
        theScale.x *= -1;
        transform.localScale = theScale;


    }

    void fireRocket()
    {
        if(Time.time > nextFire)
        {
            nextFire = Time.time + fireRate;
            if (facingRight)
            {
                Instantiate(bullet, gunTip.position, Quaternion.Euler ( new Vector3 (0,0,0)));
            }else if (!facingRight)
            {
                Instantiate(bullet, gunTip.position, Quaternion.Euler(new Vector3(0, 0, 180)));

            }

            if (useSecondGunTip == true && boost == true)  //added this myself
            {
                    nextFire = Time.time + fireRate;
                    if (facingRight)
                    {
                        Instantiate(bullet, secondGunTip.position, Quaternion.Euler(new Vector3(0, 0, 0)));
                    }
                    else if (!facingRight)
                    {
                        Instantiate(bullet, secondGunTip.position, Quaternion.Euler(new Vector3(0, 0, 180)));

                    }
                

            }
        }


       
    }

    public void increaseFireRate()  //added this myself
    {
        boost = true;
        fireRate = 0.3f;
    }
}
