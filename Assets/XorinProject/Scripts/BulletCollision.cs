using UnityEngine;

public class BulletCollision : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {
        // Check if the bullet has hit anything other than the player
        if (!collision.collider.CompareTag("Player"))
        {
            Destroy(gameObject);
        }
    }
}