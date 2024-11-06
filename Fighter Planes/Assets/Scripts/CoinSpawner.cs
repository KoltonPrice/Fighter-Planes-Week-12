using UnityEngine;

public class CoinSpawner : MonoBehaviour
{
    public GameObject coinPrefab;  // Reference to the coin prefab
    public float spawnInterval = 5.0f;  // Interval between spawns

    void Start()
    {
        InvokeRepeating("SpawnCoin", 1.0f, spawnInterval);  // Start spawning coins
    }

    void SpawnCoin()
    {
        Vector2 spawnPosition = new Vector2(Random.Range(-9f, 9f), Random.Range(-4.5f, 4.5f));
        Instantiate(coinPrefab, spawnPosition, Quaternion.identity);
    }
}
