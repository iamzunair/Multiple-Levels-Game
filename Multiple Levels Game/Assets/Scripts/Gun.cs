using System.Collections;
using UnityEngine;
using UnityEngine.InputSystem;
using TMPro;

public class Gun : MonoBehaviour
{
    public GameObject bullet;            // Reference to the bullet prefab
    public Transform transformm;         // Reference to the gun's transform
    public float bulletSpeed = 10f;      // Speed of bullets fired
    public float moveSpeed = 0.5f;       // Speed at which the gun moves
    public TextMeshProUGUI countText;    // Reference to a TextMeshProUGUI element to display the enemy count
    public GameObject winTextObject;     // Reference to a GameObject that displays a "win" message
    private Rigidbody rb;


    void Start()
    {
        rb = GetComponent<Rigidbody>();
        winTextObject.SetActive(false);   // Deactivate the winTextObject at the start

    }
    private void FixedUpdate() {
          if (Input.GetKey(KeyCode.LeftArrow))
        {
            transform.Translate(Vector3.left * moveSpeed * Time.deltaTime);
        }
        if (Input.GetKey(KeyCode.RightArrow))
        {
            transform.Translate(Vector3.right * moveSpeed * Time.deltaTime);
        }

    }

    void Update()
    {
      
        if (Input.GetButtonDown("Fire1"))
        {
            GameObject bulletInstance;
            bulletInstance = Instantiate(bullet, transformm.position, transformm.rotation);
            bulletInstance.GetComponent<Rigidbody>().velocity = transformm.forward * bulletSpeed;
           
        }
    }

     void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Enemy"))
        {
            other.gameObject.SetActive(false);  // Deactivate the collided enemy object
            GameManager.Instance.IncrementEnemyCount();  // Increase the enemy count using the GameManager
            SetCountText();  // Update the enemy count displayed in the UI
        }
    }

     void SetCountText()
    {
        countText.text = "Enemy Killed: " + GameManager.Instance.GetEnemyCount().ToString();

        if (GameManager.Instance.GetEnemyCount() >= 10)
        {
            winTextObject.SetActive(true);  // Activate the winTextObject
            Time.timeScale = 0f;  // Pause the game by setting time scale to 0
        }
    }
    
}