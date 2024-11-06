using UnityEngine;

public class HealthPowerupSpawner : MonoBehaviour
{
    public GameObject healthPowerupPrefab;  // Reference to the health powerup prefab
    public float spawnInterval = 10.0f;  // Interval between spawns

    void Start()
    {
        InvokeRepeating("SpawnHealthPowerup", 1.0f, spawnInterval);  // Start spawning health powerups
    }

    void SpawnHealthPowerup()
    {
        Vector2 spawnPosition = new Vector2(Random.Range(-9f, 9f), Random.Range(-4.5f, 4.5f));
        Instantiate(healthPowerupPrefab, spawnPosition, Quaternion.identity);
    }
}
