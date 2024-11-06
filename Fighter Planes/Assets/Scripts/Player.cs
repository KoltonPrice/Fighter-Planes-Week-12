using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    private float horizontalInput;
    private float verticalInput;
    private float horizontalScreenSize = 11.5f;
    private float verticalScreenSize = 7.5f;
    private float speed;
    private int lives;

    public GameObject bullet;
    public Text livesText;

    // Property to access lives
    public int Lives
    {
        get { return lives; }
        set
        {
            lives = Mathf.Clamp(value, 0, 3);  // Ensure lives stay between 0 and 3
            UpdateLivesText();  // Ensure the text is updated whenever lives change
        }
    }

    void Start()
    {
        speed = 6f;
        Lives = 3;  // Initialize lives using the property to ensure text is updated
        UpdateLivesText();  // Initial update of the lives text
    }

    void Update()
    {
        Movement();
        Shooting();
    }

    void Movement()
    {
        horizontalInput = Input.GetAxis("Horizontal");
        verticalInput = Input.GetAxis("Vertical");
        transform.Translate(new Vector3(horizontalInput, verticalInput, 0) * Time.deltaTime * speed);
        if (transform.position.x > horizontalScreenSize || transform.position.x <= -horizontalScreenSize)
        {
            transform.position = new Vector3(transform.position.x * -1, transform.position.y, 0);
        }
        if (transform.position.y > verticalScreenSize || transform.position.y < -verticalScreenSize)
        {
            transform.position = new Vector3(transform.position.x, transform.position.y * -1, 0);
        }
    }

    void Shooting()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Instantiate(bullet, transform.position + new Vector3(0, 1, 0), Quaternion.identity);
        }
    }

    public void LoseALife()
    {
        Lives--;  // Use property to decrease lives
        if (Lives == 0)
        {
            Destroy(this.gameObject);
        }
    }

    public void GainALife()
    {
        if (Lives < 3)
        {
            Lives++;  // Use property to increase lives
        }
    }

    public void UpdateLivesText()
    {
        if (livesText != null)
        {
            livesText.text = "Lives: " + Lives;  // Use property to get lives
        }
    }
}
