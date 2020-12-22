using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class friendlySpikeDamage : MonoBehaviour //added this myself
{
    public float damage;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
     if(other.tag == "Enemy")
        {
            enemyHealth enemy = other.GetComponentInChildren<enemyHealth>();
            enemy.addDamage(damage);
        }   
    }
}
