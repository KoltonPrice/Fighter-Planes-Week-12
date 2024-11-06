using UnityEngine;

public class HealthPowerup : MonoBehaviour
{
    public float lifetime = 2.0f;
    private Player player;

    void Start()
    {
        player = GameObject.FindObjectOfType<Player>();
        Destroy(gameObject, lifetime);  // Destroy the powerup after its lifetime
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            player.GainALife();  // Increase lives using the method
            Destroy(gameObject);
        }
    }
}
