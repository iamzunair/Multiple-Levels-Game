using UnityEngine; // Import Unity's core functionality

public class Bullet : MonoBehaviour
{
    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            Destroy(collision.gameObject); // Destroy the enemy game object
            Destroy(gameObject); // Destroy the bullet game object
            GameManager.Instance.IncrementEnemyCount(); // Increment the enemy count through the GameManager
        }

        if (collision.gameObject.CompareTag("Walls"))
        {
            Destroy(gameObject); // Destroy the bullet game object if it collides with walls
        }
    }

    void Update()
    {
        Destroy(gameObject, 2); // Automatically destroy the bullet game object after 2 seconds
    }
}
