using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
    public static PlayerHealth Instance;
    public float destructionDistance = 2.0f;
    public GameObject loseTextObject;
    private Rigidbody rb;
    public int maxHealth = 10;
    private int currentHealth;
    public Slider HealthBar;
    
    public GameObject gameOverUI;

    private void Awake()
    {
        Instance = this;
    }

    void Start()
    {
        currentHealth = maxHealth;
        rb = GetComponent<Rigidbody>();
        loseTextObject.SetActive(false);
        UpdateHealthBar(); // Initialize the health bar.
    }

    private void Update()
    {
        float distanceToClosestEnemy = CalculateDistanceToClosestEnemy();

        if (distanceToClosestEnemy <= destructionDistance)
        {
            gameOverUI.SetActive(true);
            TakeDamage(1); // Handle player defeat. Reduce health by 1 when enemy is too close.
        }
    }

    public float CalculateDistanceToClosestEnemy()
    {
        float closestDistance = float.MaxValue;
        GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy");

        foreach (var enemy in enemies)
        {
            float distance = Vector3.Distance(transform.position, enemy.transform.position);
            closestDistance = Mathf.Min(closestDistance, distance);
        }

        return closestDistance;
    }

    public void TakeDamage(int damageAmount)
    {
        currentHealth -= damageAmount;
        UpdateHealthBar(); // Update the health bar.

        if (currentHealth <= 0)
        {
           
            PlayerDefeated();
        }
    }

    private void UpdateHealthBar()
    {
        // Update the health bar slider's value based on the current health.
        HealthBar.value = (float)currentHealth / maxHealth;
    }

    private void PlayerDefeated()
    {
        gameObject.SetActive(false);
        loseTextObject.SetActive(true);
        gameOverUI.SetActive(true);
        Time.timeScale = 0f;
    }
}
