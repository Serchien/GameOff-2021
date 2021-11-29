using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpgradeBehaviour : MonoBehaviour
{

    [SerializeField] string whatUpgrade;
     enum Upgrade{
        health,
        ram,
        basicAttackDamage,
        secondaryAttackDamage,
        activateDash,
        activateShield,
        activateSecondary,
        shieldTime
    }
    


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.GetComponent<PlayerHealthManager>())
        {
            switch (whatUpgrade)
            {
                case "health":
                    {
                    AbilityData.ChangeMaxHealth(5);
                    break;
                    }
                case "ram":
                    {
                    AbilityData.ChangeMaxRam(3, 0.5f);
                    break;
                    }
                case "basicAttackDamage":
                    {
                        AbilityData.ChangeBasicAttackDamage(1);
                        break;
                    }
                case "secondaryAttackDamage":
                    {
                        AbilityData.ChangeSecondaryAttackDamage(2);
                        break;
                    }
                case "activateDash":
                    {
                        AbilityData.ActivateDash();
                        break;
                    }
                case "activateShield":
                    {
                        AbilityData.ActivateShield();
                        break;
                    }
                case "activateSecondary":
                    {
                        AbilityData.ActivateSecondary();
                        break;
                    }
                case "shieldTime":
                    {
                        AbilityData.ChangeShieldTime(0.25f);
                        break;
                    }
                default:
                    {
                        break;
                    }
            }
            Destroy(gameObject);
        }
    }
}
