using UnityEngine;

[RequireComponent(typeof(InputManager3D))]
public class PlayerShooting : MonoBehaviour
{
    [SerializeField] private GameObject bulletPrefab; // Set this via the Inspector
    [SerializeField] private Transform firePoint;     // Set this via the Inspector, where the bullet will be instantiated

    [SerializeField] private float bulletSpeed = 300f;

    private Rigidbody rb;
    private InputManager3D inputManager;

    private void Awake() 
    {
        inputManager = GetComponent<InputManager3D>();
    }

    private void Update()
    {
        // Using the new Input System to detect left mouse button press
        // That's right, new input system, but do not hard code the shoot key
        if (inputManager.Shoot)
            Shoot();
    }

    private void Shoot()
    {
        GameObject bullet = Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);

        // You should cache the rigidbody for better performance
        if (rb == null)
            rb = bullet.GetComponent<Rigidbody>();

        if (rb != null)
        {
            // Usually, when update a bullet, you are going to multipled by delta time. Since this
            rb.linearVelocity = bulletSpeed * Time.deltaTime * firePoint.forward;
        }
    }
}