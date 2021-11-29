using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawnPointBehaviour : MonoBehaviour
{
    [SerializeField] GameObject[] enemyToSpawn;
    EncounterManager manager;

    // Start is called before the first frame update
    void Start()
    {
        manager = GetComponentInParent<EncounterManager>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void EncipateSpawning()
    {
        if (manager.waveIndex > enemyToSpawn.Length - 1) return;
        else if (enemyToSpawn[manager.waveIndex] == null) return;
        LeanTween.alpha(gameObject, 1, 1f).setOnComplete(SpawnEnemy);
        //Debug.Log("Enticipating the spawn");
        //SpawnEnemy();
    }

    private void SpawnEnemy()
    {
        LeanTween.alpha(gameObject, 0, 0.1f);
        GameObject enemy = Instantiate(enemyToSpawn[manager.waveIndex]);
        enemy.GetComponent<BaseEnemy>().manager = manager;
        enemy.transform.position = transform.position;

        manager.AddEnemy();
    }
}
