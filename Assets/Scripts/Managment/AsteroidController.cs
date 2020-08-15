using System.Collections;
using UnityEngine;
using Random = UnityEngine.Random;

public class AsteroidController : MonoBehaviour
{
    [SerializeField] private float delaySpawn;
    private Transform player;
    private Vector3[] pointBarriers;
    private Coroutine spawnAsteroid;

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag(GameConstant.PlayerTag).transform;
        pointBarriers = CameraBarriers.GetCameraBarrier(player.position.y);
    }

    private void OnEnable()
    {
        if (spawnAsteroid != null) StopCoroutine(spawnAsteroid);
        spawnAsteroid = StartCoroutine(TimerAsteroid());
    }

    private IEnumerator TimerAsteroid()
    {
        yield return new WaitForSeconds(delaySpawn);
        var asteroid = AsteroidPool.GetObject(GetPointAsteroid(out Vector3 direction), direction);
        
        StartCoroutine(TimerAsteroid());
    }

    private Vector3 GetPointAsteroid(out Vector3 directionPlayer)
    {
        var randomIndex = Random.Range(0, pointBarriers.Length-1);
        var currentPoint = pointBarriers[randomIndex];
        var secondPoint = pointBarriers[randomIndex + 1];
        var directionPoint = secondPoint - currentPoint;

        var point = currentPoint + directionPoint.normalized * (directionPoint.magnitude * Random.Range(0f, 1f));

        directionPlayer = (player.position - point).normalized;

        return point - directionPlayer * 1.5f;
    }

    private void OnDrawGizmos()
    {
        if (pointBarriers == null) return;

        Gizmos.color = Color.blue;
        
        for (int i = 0; i < pointBarriers.Length - 1; i++)
        {
            Gizmos.DrawLine(pointBarriers[i], pointBarriers[i + 1]);
        }
        
    }
}
