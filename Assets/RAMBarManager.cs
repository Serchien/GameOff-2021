using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RAMBarManager : MonoBehaviour
{
    Slider slider;
    public float currentRAM;

    bool canRegenerate = true;
    float cooldownTime = 1f;
    float regen = 1f;


    private void Awake()
    {
        slider = GetComponent<Slider>();
    }

    private void FixedUpdate()
    {
        if (canRegenerate)
        {
            slider.value += AbilityData.ramRechargeRate * Time.deltaTime;
        }
    }

    private void Update()
    {
        currentRAM = slider.value;
    }



    public void SetRAM(int value)
    {
        slider.maxValue = value;
        slider.value = value;
    }

    public void DecreaseRAM(int value)
    {
        slider.value -= value;
        canRegenerate = false;
        StopCoroutine(RegenerationCoolDown());
        StartCoroutine(RegenerationCoolDown());
    }

    public void IncreaseRAM(int value)
    {
        slider.value += value;
    }

    IEnumerator RegenerationCoolDown()
    {
        yield return new WaitForSeconds(1f);
        canRegenerate = true;
    }

    public void ChangeMaxRamBar()
    {
        slider.maxValue = AbilityData.maxRam;
    }
}
