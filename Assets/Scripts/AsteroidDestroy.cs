using UnityEngine;

public class AsteroidDestroy : MonoBehaviour
{
    [SerializeField] private GameObject particle;
    private Asteroid thisAsteroid;

    private void Start()
    {
        thisAsteroid = GetComponent<Asteroid>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag(GameConstant.BulletTag))
        {
            EventManager.OnAsteroidDestroy?.Invoke();
            AudioEnvironment.ExplosionAudio();
            DestroyAsteroid();
            other.gameObject.SetActive(false);
        }
    }

    public void DestroyAsteroid()
    {
        AsteroidPool.ReturnObject(thisAsteroid);
        Destroy(Instantiate(particle, transform.position, Quaternion.identity), 2f);
    }
}
