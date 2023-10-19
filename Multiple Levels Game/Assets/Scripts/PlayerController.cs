using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float movementSpeed = 5.0f;
    public float recoveryForce = 10.0f; // The force to counteract sliding

    private Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void FixedUpdate()
    {
        // Handle player movement here.
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("EnemyBullet"))
        {
            // Calculate the force direction to counteract sliding
            Vector3 forceDirection = -collision.relativeVelocity.normalized;

            // Apply a force in the opposite direction to counteract sliding
            rb.AddForce(forceDirection * recoveryForce, ForceMode.Impulse);
        }
    }
}
