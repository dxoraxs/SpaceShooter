using UnityEngine;

public class PlayerShip : MonoBehaviour
{
    [SerializeField] private GameObject particle;
    private int health;

    private void Start()
    {
        StartHealth();
    }

    public void StartHealth()
    {
        health = GameSettings.GetPlayerSettings.Health;
    }

    private void TakeDamage()
    {
        health--;
        EventManager.OnUpdateHealth?.Invoke();
        if (health <= 0)
        {
            Death();
        }
    }

    private void Death()
    {
        Destroy(Instantiate(particle, transform.position, Quaternion.identity), 2f);
        gameObject.SetActive(false);
        GameManager.PlayerDied();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent(out AsteroidDestroy asteroid))
        {
            asteroid.DestroyAsteroid();
            TakeDamage();
        }
    }
}
