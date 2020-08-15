using UnityEngine;

public class KeyboardInput : MonoBehaviour
{
    private MotorObject motor;

    private void Awake()
    {
        
#if !UNITY_EDITOR
        Destroy(this);
        return;
#endif
        motor = GetComponent<MotorObject>();
    }
    
    private void Update()
    {
        float verticalAxis = Input.GetAxis("Vertical");
        float horizontalAxis = Input.GetAxis("Horizontal");
        var direction = new Vector3(horizontalAxis, 0, verticalAxis);
        motor.Move(direction.normalized);
    }
}