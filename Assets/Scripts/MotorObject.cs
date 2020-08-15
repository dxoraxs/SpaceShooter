using UnityEngine;

public class MotorObject : MonoBehaviour
{
    [SerializeField] private float offsetCameraBarrier = 1;
    private float speedMax;
    private float speed;

    private void Start()
    {
        speedMax = GameSettings.GetPlayerSettings.Speed;
    }

    public void Move(Vector3 direction)
    {
        var inputValue = direction.magnitude == 0;
        float deltaTime = Time.deltaTime;
        speed = Mathf.Clamp(speed + (inputValue ? -4 : 1) * 4 * deltaTime, 0, speedMax);

        Vector3 stepPosition = direction * speed * deltaTime;
        var nextPosition = transform.position + stepPosition;
        if (nextPosition.x < CameraBarriers.LeftBorrier + offsetCameraBarrier || nextPosition.x > CameraBarriers.RightBorrier - offsetCameraBarrier)
            stepPosition.x = 0;
        if (nextPosition.z < CameraBarriers.BottomBorrier + offsetCameraBarrier || nextPosition.z > CameraBarriers.TopBorrier - offsetCameraBarrier)
            stepPosition.z = 0;

        transform.position += stepPosition;
    }
}
