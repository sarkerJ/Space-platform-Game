using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class projectileSummon : MonoBehaviour //added this myself
{
    public GameObject projectile;
    public float timeBetweenShooting;
    public Transform shootStartLocation;
    public Transform shootStartLocation1;
    public Transform shootStartLocation2;
    public Transform shootStartLocation3;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerStay2D(Collider2D other)
    {
        if (other.tag == "Player" && timeBetweenShooting < Time.time)
        {
            timeBetweenShooting = Time.time + 2f;
            
                Instantiate(projectile, shootStartLocation.position, shootStartLocation.rotation);
                Instantiate(projectile, shootStartLocation1.position, shootStartLocation1.rotation);
                Instantiate(projectile, shootStartLocation2.position, shootStartLocation2.rotation);
                Instantiate(projectile, shootStartLocation3.position, shootStartLocation3.rotation);
        }
    }
}
