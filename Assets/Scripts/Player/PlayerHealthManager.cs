using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealthManager : MonoBehaviour
{
    public static int health = 20;
    //int maxHealth = 20;

    HealthBarManager playerHealthBar;


    // Start is called before the first frame update
    void Start()
    {
        playerHealthBar = PlayerManager.playerHealthBar;
        playerHealthBar.SetHealth(health);

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void DecreaseHealth(int value)
    {
        health -= value;
        playerHealthBar.DecreaseHealth(value);

        if(health < 1)
        {
            GameEvent.RaiseEvent("PlayerDeath");
            ResetHealth();
        }
    }
    public void IncreaseValue(int value)
    {
        playerHealthBar.IncreaseHealth(value);
    }

    private void ResetHealth()
    {
        health = AbilityData.maxHealth;
        playerHealthBar.SetHealth(AbilityData.maxHealth);
    }

}
