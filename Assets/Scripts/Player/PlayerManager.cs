using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    static public GameObject Player;
    static public HealthBarManager playerHealthBar;
    static public RAMBarManager playerRAM;

    static public bool dashUnlocked = true;
    static public bool secondaryAttackUnlocked = false;

    int maxRAM = 10;

    private void Awake()
    {
        Player = GameObject.FindGameObjectWithTag("Player");
        playerHealthBar = GetComponentInChildren<HealthBarManager>();
        playerRAM = GetComponentInChildren<RAMBarManager>();
    }

    // Start is called before the first frame update
    void Start()
    {
        playerRAM.SetRAM(maxRAM);

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
