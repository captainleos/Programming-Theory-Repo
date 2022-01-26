using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    [SerializeField] GameObject enemyPrefab;
    private float spawnRange = 500.0f;
    private float spawnCount = 3;

    private void Start()
    {
        SpawnEnemyWave();
    }

    void SpawnEnemyWave()
    {
        for (int i=0; i < spawnCount; i++)
        {
            Instantiate(enemyPrefab, GenerateSpawnPosition(), enemyPrefab.transform.rotation);
        }
    }

    private Vector3 GenerateSpawnPosition()
    {
        float spawnPosX = Random.Range(-spawnRange, spawnRange);
        float spawnPosZ = Random.Range(-spawnRange, spawnRange);

        Vector3 randomPos = new Vector3(spawnPosX, 0.627f, spawnPosZ);

        return randomPos;
    }
}
