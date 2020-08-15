using UnityEngine;

public class ObjectFlyMap : MonoBehaviour
{
    [SerializeField] private float speed;
    private Vector3 direction;

    public void InitObject(Vector3 direction)
    {
        this.direction = direction;
    }

    private void Update()
    {
        transform.position += direction * speed * Time.deltaTime;
    }
}
