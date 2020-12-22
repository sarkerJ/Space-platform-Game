using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class playerHealth : MonoBehaviour
{
    public restartGame theGameManager; 
    public float fullHealth;

    float currentHealth;

    playerController controlMovement;
    public GameObject deathFX;
    public AudioClip playerHurt;

    public AudioClip playerDeathSound;
    AudioSource playerAS;

    //HUD Variables
    public Slider healthSlider;
    public Image damageScreen;
    public Text gameOverScreen;
    public Text winGameScreen;

    bool damaged = false;
    Color damagedColour = new Color(5f, 0f, 0f, 1f); //changed myself
    float smoothColour = 5f;


    // Start is called before the first frame update
    void Start()
    {
        currentHealth = fullHealth;

        controlMovement = GetComponent<playerController>();

        //HUD initialisation

        healthSlider.maxValue = fullHealth;
        healthSlider.value = fullHealth;

        damaged = false;

        playerAS = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if(damaged == true)
        {
            damageScreen.color = damagedColour;
        }else
        {
            damageScreen.color = Color.Lerp(damageScreen.color, Color.clear,smoothColour*Time.deltaTime);
        }
        damaged = false;

    }

    public void addDamage(float damage)
    {
        if (damage <= 0) return; //option to allow stuff to hit us but not damage us
        currentHealth = currentHealth - damage;
        
            playerAS.clip = playerHurt;
            playerAS.Play();
        
        healthSlider.value = currentHealth;
        damaged = true;

        if(currentHealth <= 0)
        {
            makeDead();
        }
    }

    public void addHealth(float healthAmount)
    {
        currentHealth += healthAmount;
        if (currentHealth > fullHealth) currentHealth = fullHealth;// if current is higher set it to our max health
        healthSlider.value = currentHealth;
    }

    public void makeDead()
    {
        Instantiate(deathFX, transform.position, transform.rotation);
        Destroy(gameObject);
        AudioSource.PlayClipAtPoint(playerDeathSound,transform.position); //plays the sound where the player dies
        damageScreen.color = damagedColour;

        Animator gameOverAnimator = gameOverScreen.GetComponent<Animator>();
        gameOverAnimator.SetTrigger("gameOver");
        theGameManager.restartTheGame();
    }

    public void winGame()
    {
        Destroy(gameObject);
        //theGameManager.restartTheGame();
        theGameManager.finishTheGame();              //added myself
        Animator winGameAnimator = winGameScreen.GetComponent<Animator>();
        winGameAnimator.SetTrigger("gameOver");
    }

    public void turnOnSafePoint()                  //added this myself
    {
        theGameManager.safePointPortalActive();
    }

}
