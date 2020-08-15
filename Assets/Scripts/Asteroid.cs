using System.Collections;
using UnityEngine;

public class Asteroid : ObjectFlyMap
{
    private Vector3 rotate;
    private Coroutine destroyAsteroid;
    
    private void OnEnable()
    {
        if (destroyAsteroid != null) StopCoroutine(destroyAsteroid);
        transform.rotation = Quaternion.Euler(Random.insideUnitSphere * 360);
        transform.localScale = Vector3.one * Random.Range(0.7f, 1.3f);
        destroyAsteroid = StartCoroutine(ReturnObject());
    }

    private IEnumerator ReturnObject()
    {
        yield return new WaitForSeconds(16);
        AsteroidPool.ReturnObject(this);
        destroyAsteroid = null;
    }
}
