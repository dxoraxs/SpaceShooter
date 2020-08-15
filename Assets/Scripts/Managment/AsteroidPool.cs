using UnityEngine;

public class AsteroidPool : PoolObject<Asteroid>
{
    protected override void ProcessingObject(Asteroid _object, Vector3 direction)
    {
        _object.InitObject(direction);
    }
}
