using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class sunProjectile : MonoBehaviour //added this myself
{

    public float projectileSpeed;
    Rigidbody2D myRB;
    public float damage;
    // Start is called before the first frame update
    void Awake()
    {
        myRB = GetComponent<Rigidbody2D>();
        myRB.AddForce(new Vector2(-1, 0) * projectileSpeed, ForceMode2D.Impulse);  // (when z is greater ) meaning ur facing left so rocket should fly left
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
     if(other.tag == "Player")
        {
            playerHealth player = other.GetComponent<playerHealth>();
            player.addDamage(damage);
            Destroy(gameObject);
        }   
      else if (other.gameObject.layer == LayerMask.NameToLayer("Protective")) //included this top bit of if myself
        {
            Destroy(gameObject);
        }
    }
}
