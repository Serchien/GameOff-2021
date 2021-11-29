using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

[CreateAssetMenu(menuName ="Level/Encounter")]
public class RoomData : ScriptableObject
{
    public Wave[] waves;
}

[Serializable]
public class Wave
{
    public SpawnPoint[] spawnPoints;
}

[Serializable]
public class SpawnPoint
{
    public Transform spawnPosition;
    public GameObject enemyPF;
}
