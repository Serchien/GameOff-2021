using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

[CreateAssetMenu(menuName ="New Enemy")]
public class EnemyData : ScriptableObject
{
    public EnemyPowerLevel[] powerLevel;

}

[Serializable]
public class EnemyPowerLevel
{
    [Range(1, 100)] public int maxHitPoint;
    [Range(1, 20)] public int damage;
    [Range(0.5f, 5f)] public float cooldown;
    [Range(0f, 10f)] public float range;
    [Range(0f, 5f)] public float enticipationTime;


    [Range(1, 5)] public int NbOfAttacks;
    [Range(0f, 3f)] public float timeBetweenAttacks;

}
