using System.Collections.Generic;
using UnityEngine;

public abstract class PoolObject<T> : MonoBehaviour where T : MonoBehaviour
{
    private static PoolObject<T> instance;
    [SerializeField] private T objectPrefab;
    [SerializeField] private int countPool;
    private List<T> pool = new List<T>();
    private List<T> useObject = new List<T>();

    private void Awake()
    {
        if (instance != null)
        {
            Destroy(gameObject);
            return;
        }
        instance = this;
        //EventManager
    }

    private void ClearPool()
    {
        foreach (var value in useObject)
        {
            AddDisable(value);
        }
        useObject.Clear();
    }
    
    private void Start()
    {
        for (int i = 0; i < countPool; i++)
        {
            SpawnObject();
        }
    }

    private void SpawnObject()
    {
        var _object = Instantiate(objectPrefab, transform);
        AddDisable(_object);
    }

    private void AddDisable(T _object)
    {
        if (_object == null || _object.gameObject == null) return;
        pool.Add(_object);
        _object.gameObject.SetActive(false);
    }

    public static void ClearAsteroid()
    {
        instance.ClearPool();
    }

    public static T GetObject(Vector3 position, Vector3 direction)
    {
        if (instance.pool.Count <= 0)
        {
            instance.SpawnObject();
        }

        var currentObject = instance.pool[0];
        instance.pool.Remove(currentObject);
        currentObject.transform.position = position;
        currentObject.gameObject.SetActive(true);
        instance.ProcessingObject(currentObject, direction);
        instance.useObject.Add(currentObject);
        return currentObject;
    }

    protected abstract void ProcessingObject(T _object, Vector3 direction);

    public static void ReturnObject(T _object)
    {
        if (instance.pool.Contains(_object)) return;
        instance.useObject.Remove(_object);
        instance.AddDisable(_object);
    }
}
