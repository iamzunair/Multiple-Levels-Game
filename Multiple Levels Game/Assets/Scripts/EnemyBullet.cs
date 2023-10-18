using UnityEngine;

public class EnemyBullet : MonoBehaviour
{
    public int damageAmount = 1; // Define the damage amount for the enemy bullet

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            // Deal damage to the player
            collision.gameObject.GetComponent<PlayerHealth>().TakeDamage(damageAmount);

            // Destroy the bullet
            Destroy(gameObject);
        }
    }
}
