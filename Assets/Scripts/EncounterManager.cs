using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EncounterManager : MonoBehaviour
{
    public int waveIndex = 0;
    [SerializeField] int maxRoomIndex = 1;
    bool roomCleared = false;
    bool roomInitiated = false;

    List<EnemySpawnPointBehaviour> spawnpoints = new List<EnemySpawnPointBehaviour>();
    int enemyReamaining = 0;
    //[SerializeField] RoomData roomData;

    private void Start()
    {
        
        foreach(EnemySpawnPointBehaviour sp in GetComponentsInChildren<EnemySpawnPointBehaviour>())
        {
            spawnpoints.Add(sp);
        }
    }

    public void OnRoomEnter()
    {
        if (roomCleared || roomInitiated) return;
        roomInitiated = true;
        NewWave();

        
    }
    void NewWave()
    {
        if (waveIndex > maxRoomIndex) roomCleared = true;
        foreach (EnemySpawnPointBehaviour sp in spawnpoints)
        {
            //EnemySpawnPointBehaviour spBrain = sp.GetComponent<EnemySpawnPointBehaviour>();
            sp.EncipateSpawning();
        }
    }

    public void AddEnemy()
    {
        enemyReamaining++;
    }

    public void RemoveEnemy()
    {
        enemyReamaining--;
        if(enemyReamaining == 0)
        {
            waveIndex++;
            NewWave();
        }
    }


}
