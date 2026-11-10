using UnityEngine;
using UnityEngine.InputSystem; // for the Input System types

public class PlayerShooting : MonoBehaviour
{
    public GameObject bulletPrefab; // Set this via the Inspector
    public Transform firePoint;     // Set this via the Inspector, where the bullet will be instantiated
    public float bulletSpeed = 20f;

    void Update()
    {
        // Using the new Input System to detect left mouse button press
        if (Mouse.current.leftButton.wasPressedThisFrame)
        {
            Shoot();
        }
    }

    void Shoot()
    {
        GameObject bullet = Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
        Rigidbody rb = bullet.GetComponent<Rigidbody>();
        if (rb != null)
        {
            rb.linearVelocity = firePoint.forward * bulletSpeed;
        }
    }
}