using UnityEngine;

public class EnemyShoot : MonoBehaviour
{
    public GameObject bulletPrefab;
    public Transform bulletSpawnPoint;
    public float bulletSpeed = 10f;  // Set the bullet speed to 10 units per second
    public float timeBetweenShots = 2f;
    private float nextShotTime;

    public int maxBullets = 3;
    private int bulletsFired;

    void Start()
    {
        nextShotTime = Time.time + Random.Range(0f, timeBetweenShots);
        bulletsFired = 0;
    }

    void Update()
    {
        if (bulletsFired < maxBullets && Time.time >= nextShotTime)
        {
            // Check for obstructions before shooting
            if (!ObstructionInFront())
            {
                Shoot();
                bulletsFired++;
                nextShotTime = Time.time + timeBetweenShots;
            }
        }
    }

    void Shoot()
    {
        // Calculate the direction of the enemy's movement
        Vector3 enemyDirection = -transform.forward.normalized;

        GameObject bullet = Instantiate(bulletPrefab, bulletSpawnPoint.position, Quaternion.identity);
        Rigidbody rb = bullet.GetComponent<Rigidbody>();
        rb.velocity = enemyDirection * bulletSpeed;
    }

    bool ObstructionInFront()
    {
        RaycastHit hit;
        Vector3 rayDirection = -transform.forward;

        if (Physics.Raycast(bulletSpawnPoint.position, rayDirection, out hit, 5f)) {
            if (hit.collider.CompareTag("Enemy")) {
                // There's another enemy in front
                return true;
            }
        }

        return false;
    }

}
