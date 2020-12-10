using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeroStamina : MonoBehaviour
{
    HeroStats heroStats;
    public StaminaBar staminabar;

    public int CurrentStamina;
    public int StaminaMultiplier;
    public int StaminaCalculation;
    public int maxStamina;
    public int StaminaDelay; 
    

    void Start()
    {
        
        StaminaDelay = 0;
        heroStats = gameObject.GetComponent<HeroStats>();
        CurrentStamina = maxStamina;
        staminabar.SetMaxStamina(CurrentStamina);
    }
    void Update()
    {
        StaminaMultiplier = maxStamina / 10; 
    }
    public void staminaConsumption(int StaminaCost)
    {
        CurrentStamina = CurrentStamina - StaminaCost; // / StaminaCalculation;
        StaminaDelay = 0;
        staminabar.SetStamina(CurrentStamina);
    }
    public void SetStamina(int StaminaM)
    {
        maxStamina = StaminaM;
        if (CurrentStamina != maxStamina)
        {
            CurrentStamina = maxStamina;
            staminabar.SetMaxStamina(maxStamina);
        }


    }
    void FixedUpdate() //Stamina regeneration
    {
       if (StaminaDelay <= 150)
        {
            StaminaDelay++;
        }
            
        
        
        if (StaminaDelay >= 150 && CurrentStamina < maxStamina)
        {
            CurrentStamina++;
            staminabar.SetStamina(CurrentStamina);

        }
    }

}
