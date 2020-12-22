using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rocketHit : MonoBehaviour
{

    public float weaponDamage;
    projectileController myPC;

    public GameObject explosionEffect;
  

    // Start is called before the first frame update
    void Awake()
    {
        myPC = GetComponentInParent<projectileController>();
    }

    // Update is called once per frame
    void Update()
    {
       
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.layer == LayerMask.NameToLayer("Protective")) return; //added this myself

        if (other.gameObject.layer == LayerMask.NameToLayer("Shootable"))
        {
            myPC.removeForce();
            Instantiate(explosionEffect, transform.position, transform.rotation);
            Destroy(gameObject);//destroys the rocket object which also includes the particle
            if(other.tag == "Enemy") //check if collider is part of a gameobject tagged as "Enemy" do the following
            {
                enemyHealth hurtEnemy = other.gameObject.GetComponent<enemyHealth>(); // from tht enemy object get the enemyhealth script in it and add the damage input
                hurtEnemy.addDamage(weaponDamage); 
                
            }
        }

    }

    private void OnTriggerStay2D(Collider2D other)
    {
        if (other.gameObject.layer == LayerMask.NameToLayer("Protective")) return; //added this myself

        if (other.gameObject.layer == LayerMask.NameToLayer("Shootable"))
        {
            myPC.removeForce();
            Instantiate(explosionEffect, transform.position, transform.rotation);
            Destroy(gameObject);
            if (other.tag == "Enemy") //check if collider is part of a gameobject tagged as "Enemy" do the following
            {
                enemyHealth hurtEnemy = other.gameObject.GetComponent<enemyHealth>(); // from tht enemy object get the enemyhealth script in it and add the damage input
                hurtEnemy.addDamage(weaponDamage);

            }
        }
    }

  
}
