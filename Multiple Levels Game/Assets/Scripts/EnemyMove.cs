using UnityEngine;

public class EnemyMove : MonoBehaviour
{
    public float enemySpeed = 2;
    public GameObject enemy;
    void Update()
    {
        {
            // Move the enemy forward
            transform.Translate(-Vector3.forward * enemySpeed * Time.deltaTime);
        }
    }

}


