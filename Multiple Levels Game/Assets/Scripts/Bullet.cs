using UnityEngine;

public class Bullet : MonoBehaviour
{
    
    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            Destroy(collision.gameObject);

            // Destroy the bullet
            Destroy(gameObject);

            // Increase the count of enemies killed
            GameManager.Instance.IncrementEnemyCount();

            // Check if the win condition is met
            if (GameManager.Instance.GetEnemyCount() >= 50)
            {
                // Display game over text and pause the game
                GameManager.Instance.GameOver();
            }

            if (collision.gameObject.CompareTag("Walls"))
            {
                Destroy(gameObject);
            }
        }
    }

    void Update()
    {
        Destroy(gameObject, 2);
    }
}

