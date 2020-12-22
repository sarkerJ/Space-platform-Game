using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class enemyHealth : MonoBehaviour
{

    public float enemyMaxHealth;
    float currentHealth;
    public GameObject enemyDeathFX;
    public Slider enemySlider;

    public bool drops;
    public GameObject theDrop;

    public AudioClip deathKnell;

    // Start is called before the first frame update
    void Start()
    {
        currentHealth =enemyMaxHealth;
        enemySlider.maxValue = currentHealth;
        enemySlider.value = currentHealth;
    }
    // Update is called once per frame
    void Update()
    {
        
    }


    public void addDamage(float damage)
    {
        enemySlider.gameObject.SetActive(true);
        currentHealth = currentHealth - damage; //changing current health minus damage
        enemySlider.value = currentHealth;
        if(currentHealth <= 0) makeDead(); // if its less or equal to 0, we will destroy the enemy
    }

   public void makeDead()
    {
        Destroy(gameObject.transform.parent.gameObject); //deleting the object that this smaller object is a child of
        AudioSource.PlayClipAtPoint(deathKnell, transform.position);
        Instantiate(enemyDeathFX, transform.position, transform.rotation);
        if (drops) Instantiate(theDrop, transform.position, transform.rotation); //it will drop the "thedrop" where the last position of enemy was


    }

}
