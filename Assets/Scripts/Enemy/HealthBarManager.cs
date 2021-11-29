using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBarManager : MonoBehaviour
{
    Slider slider;

    private void Awake()
    {
        slider = GetComponent<Slider>();
    }

    void Start()
    {
        slider = GetComponent<Slider>();
    }

    public void SetHealth(int value)
    {
        slider.maxValue = value;
        slider.value = value;
    }

    public void DecreaseHealth(int value)
    {
        slider.value -= value;
    }
    
    public void IncreaseHealth(int value)
    {
        slider.value += value;
    }

    public void ChangeMaxHealthBar()
    {
        slider.maxValue = AbilityData.maxHealth;
    }

}
