using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Campfire : MonoBehaviour
{
    public HeroStats heroStats;
    public HeroCurrency heroCurrency;

    public Transform heroPosition;
    public Transform SavePosition;

    //If player is in range + Pushes e - Open menu
    void Start()
    {
    }

    //float distance = Vector3.Distance (object1.transform.position, object2.transform.position);
    void Update()
    {
        // float distance = Vector3.Distance (heroPosition.position, SavePosition.position);
        if (Input.GetKeyDown("e"))
        {
            if (Vector3.Distance(heroPosition.position, SavePosition.position) <= 10)
            {
                SaveGame();
                Debug.Log("Saved Succesfully");
            }
            else
            {
                Debug.Log("Too far away");
            }
        }
    }

    void SaveGame()
    {
        //Save Stats
        heroStats.SaveStats();

        //Save Currency
        heroCurrency.SaveCurrency();

        //Save Inventory
        //Save Inventory Method
    }
}