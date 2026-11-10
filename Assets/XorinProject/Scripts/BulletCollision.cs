using UnityEngine;
using UnityGameStarter.TimerSystem;

public class BulletCollision : MonoBehaviour
{
    [SerializeField] private float destructionDelay = 10f;
    private Timer timer;

    private void Start()
    {
        // This way will make it easier for setup and start the timer
        timer = TimerManager.Instance.CreateTimer(this, destructionDelay, "Bullet Timer");

        if (destructionDelay > 0)
            timer.BindCompleted(() => Destroy(gameObject));
        else
            Destroy(gameObject);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (!collision.collider.CompareTag("Player"))
        {
            Destroy(gameObject);
        }
    }

    // Do not forget to cancel and unregister the timer if destroyed
    private void OnDestroy()
    {
        if (timer.RemainingTime > 0)
            timer.Cancel();

        TimerManager.Instance.Unregister(timer);
    }
}