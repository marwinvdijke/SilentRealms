using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{

    public int maxHealth = 100;
    int currentHealth;

    public BossBar bossbar;
    public HeroLoot heroloot;

    public GameObject enemy;
    public GameObject slimeGFX;

    public Rigidbody2D rb;





    // Start is called before the first frame update
    void Start()
    {
        currentHealth = maxHealth;
        bossbar.SetMaxBossHealth(maxHealth);

    }

    public void TakeDamage(int damage)
    {
        currentHealth -= damage;

        bossbar.SetBossHealth(currentHealth);

        // hurt ani
        if (currentHealth <= 0)
        {
            Die();
            heroloot.GetLoot();
        }
    }

    void Die()
    {

        Debug.Log("Enemy died!");

        //die ani
        Animator animator = slimeGFX.GetComponent<Animator>();
        animator.SetBool("Death", true);

        //Disable
        enemy.GetComponent<Collider2D>().enabled = false;
        GetComponent<EnemyAI>().enabled = false;
        rb.gravityScale = 0;


        this.enabled = false;
    }




}

