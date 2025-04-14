using UnityEngine;
using Unity.Mathematics;

public class CoinSpawner : MonoBehaviour
{
    private GameObject player;
    public GameObject coinPrefab;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Awake()
    {
        player = GameObject.Find("Player");
    }
    void Start()
    {
        InvokeRepeating("GenerateCoin", .5f, 0.2f);
    }

    private void GenerateCoin()
    {
        float xPos = player.transform.position.x + 30f;
        Vector3 spawnPos = new Vector3(xPos, 0.2f, 0f);
        if (UnityEngine.Random.value <= 0.08f)
            Instantiate(coinPrefab, spawnPos, quaternion.identity);
    }


}
