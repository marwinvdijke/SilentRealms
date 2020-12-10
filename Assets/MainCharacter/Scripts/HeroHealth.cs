using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HeroHealth : MonoBehaviour
{

    public int maxHealth = 100;
    public int currentHealth;

    public HealthBar healthbar;
    public HeroKnight heroknight;
    public GameObject heartbeat;

    public bool Crash = false;



    // Start is called before the first frame update
    void Start()
    {
        currentHealth = maxHealth;
        healthbar.SetMaxHealth(maxHealth);

        heroknight = gameObject.GetComponent<HeroKnight>();

        //StartCoroutine(heartbeatt());

    }

    
    /*public IEnumerator heartbeatt()
    {
        if(currentHealth <= 25)
        {
            
            heartbeat.SetActive(true);
            yield return new WaitforSeconds(1f);
            heartbeat.SetActive(false);
            yield return new WaitforSeconds(1f);
        }

        yield return null;


    }*/

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Q))
        {
            TakeDamage(20);
            heroknight.Damage();
            if (currentHealth <= 0)
            {
                heroknight.Death();
                currentHealth = maxHealth;
                healthbar.SetMaxHealth(maxHealth);
            }

           
        }
       /* if (currentHealth <= 25 & Crash == false)
        {
            Invoke("HeartBeatOn", 1);
            heartbeat.SetActive(true);
            Invoke ("HeartBeatOff", 1);



        }
        else
        {
            heartbeat.SetActive(false);
        }*/


    }
    void TakeDamage(int damage)
    {
        currentHealth -= damage;

        healthbar.SetHealth(currentHealth);

    }

    public void SetHealth(int health)
    {
        maxHealth = health;
        if (currentHealth != maxHealth)
        {
            currentHealth = maxHealth;
            healthbar.SetMaxHealth(maxHealth);
        }
    }

    /*public void UpdateStats(int health)
    {
        Debug.Log("Hey");
        maxHealth = health;
    }*/

    /*void HeartBeatOn()
    {
        Crash = true;
        heartbeat.SetActive(true);
        Invoke("HeartBeatOff", float.Parse("0.01")); 
    }

    void HeartBeatOff()
    {
        heartbeat.SetActive(false);
        Crash = false;
    }*/
}


