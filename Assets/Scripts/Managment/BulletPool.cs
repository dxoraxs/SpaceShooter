using UniRx;
using UnityEngine;

public class BulletPool : PoolObject<ObjectFlyMap>
{
    protected override void ProcessingObject(ObjectFlyMap _object, Vector3 direction)
    {
        _object.InitObject(direction);

        Observable.Timer(System.TimeSpan.FromSeconds(5))
        .Subscribe(_ =>
        {
            ReturnObject(_object);
        });
    }
}
