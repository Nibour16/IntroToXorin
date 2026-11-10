using UnityEngine;
using UnityGameStarter.TimerSystem;

public class BulletCollision : MonoBehaviour
{
    [SerializeField] private float destructionDelay = 10f;
    private Timer timer;

    void Start()
    {
        timer = new Timer(this, destructionDelay, "Bullet Timer", TimerType.Default);
        timer.BindCompleted(() => Destroy(gameObject));
        timer.Start();
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (!collision.collider.CompareTag("Player"))
        {
            Destroy(gameObject);
        }
    }
}
