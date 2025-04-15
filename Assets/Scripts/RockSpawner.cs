using UnityEngine;
using System.Collections.Generic;
using Unity.Mathematics;

public class RockSpawner : MonoBehaviour
{
    public GameObject[] rockPrefab;
    public Transform player;
    Vector3 spawnPos;
    void Start()
    {
        InvokeRepeating("rockSpawner", 0.1f, 5f);
    }
    void Update()
    {
        float randomX = UnityEngine.Random.Range(20f, 31f);
        spawnPos = new Vector3(player.position.x + randomX, -0.2f, 0);

    }
    void rockSpawner()
    {
        if (UnityEngine.Random.value <= 0.25f)
        {
            int randomNumber = UnityEngine.Random.Range(0, rockPrefab.Length);
            Instantiate(rockPrefab[randomNumber], spawnPos, quaternion.identity);
        }
    }

}
