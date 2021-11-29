using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class AbilityData
{
    public static int playerXp = 0;
    public static int playerLevel = 0;

    [Header("Basic Data")]
    public static int maxHealth = 20;
    public static int maxRam = 10;
    public static float ramRechargeRate = 1f;
    public static int basicAttackDamage  = 2;


    [Header("Secondary Data")]
    public static bool isSecondaryAttackActive = false;
    public static int secondaryAttackDamage = 5;

    [Header("Dash")]
    public static bool isDashActive = false;

    [Header("Shield")]
    public static bool isShieldActive = false;
    public static float shieldTime = 1f;


    public static void ChangeMaxHealth(int value)
    {
        maxHealth += value;
        GameEvent.RaiseEvent("NewMaxHealth");
    }
    public static void ChangeMaxRam(int value, float rateValue)
    {
        maxRam += value;
        ramRechargeRate += rateValue;
        GameEvent.RaiseEvent("NewMaxRam");

    }
    public static void ChangeBasicAttackDamage(int value)
    {
        basicAttackDamage += value;
    }
    public static void ChangeSecondaryAttackDamage(int value)
    {
        secondaryAttackDamage += value;
    }
    public static void ActivateDash()
    {
        isDashActive = true;
        GameEvent.RaiseEvent("ShowDash");
    }
    public static void ActivateSecondary()
    {
        isSecondaryAttackActive = true;
        GameEvent.RaiseEvent("ShowSecondary");
    }
    public static void ActivateShield()
    {
        isShieldActive = true;
        GameEvent.RaiseEvent("ShowShield");
    }
    public static void ChangeShieldTime(float value)
    {
        shieldTime += value;
    }

}
