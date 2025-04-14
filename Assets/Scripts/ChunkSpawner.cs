using System;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

public class ChunkPooler : MonoBehaviour
{
    public GameObject chunkprefab;
    public int poolSize = 5;
    public float chunkWidth = 20f;
    public Transform player;

    private Queue<GameObject> chunkPool = new Queue<GameObject>();
    private Vector3 spawnPosition;


    void Start()
    {
        spawnPosition = Vector3.zero;

        for (int i = 0; i < poolSize; i++)
        {
            GameObject chunk = Instantiate(chunkprefab, spawnPosition, quaternion.identity);
            chunk.SetActive(false);
            chunkPool.Enqueue(chunk);
            spawnPosition.x += chunkWidth;
        }

        foreach (var chunk in chunkPool)
        {
            chunk.SetActive(true);
        }


    }


    void Update()
    {
        GameObject firstChunk = chunkPool.Peek();
        float distanceToPlayer = player.position.x - firstChunk.transform.position.x;




        if (distanceToPlayer > chunkWidth + chunkWidth / 2)
        {
            GameObject recycledChunk = chunkPool.Dequeue();
            recycledChunk.transform.position = spawnPosition;
            spawnPosition.x += chunkWidth;

            chunkPool.Enqueue(recycledChunk);
        }


    }

}
