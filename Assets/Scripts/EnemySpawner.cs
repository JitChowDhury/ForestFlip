using System.Collections;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public GameObject enemyPrefab;
    public Transform player;
    public float spawnInterval = 2f;
    public float spawnDistance = 30f;
    public float spawnRangeX = 10f;

    void Start()
    {
        InvokeRepeating("SpawnEnemy", 1f, spawnInterval);
    }

    void SpawnEnemy()
    {  // Calculate spawn position in front of the player
        Vector3 spawnPos = new Vector3(player.position.x + spawnDistance, -0.2f, 0f);

        // Instantiate the enemy

        if (Random.value <= 0.3f)
            Instantiate(enemyPrefab, spawnPos, Quaternion.identity);
    }
}
