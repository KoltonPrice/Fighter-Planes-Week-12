using UnityEngine;

public class Coin : MonoBehaviour
{
    public float lifetime = 2.0f;  // Lifetime of the coin
    private GameManager gameManager;

    void Start()
    {
        gameManager = GameObject.FindObjectOfType<GameManager>();
        Destroy(gameObject, lifetime);  // Destroy the coin after its lifetime
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            gameManager.EarnScore(1);  // Increase score by 1
            Destroy(gameObject);  // Destroy the coin
        }
    }
}
