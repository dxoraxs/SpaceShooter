using UnityEngine;

public class JoystickInput : MonoBehaviour
{
    [SerializeField] private Joystick joystick;

    private MotorObject motor;

    private void Awake()
    {
#if UNITY_EDITOR
        Destroy(joystick.gameObject);
        Destroy(this);
        return;
#endif
        motor = GetComponent<MotorObject>();
    }

    private void Update()
    {
        var direction = new Vector3(joystick.Horizontal, 0, joystick.Vertical);
        motor.Move(direction.normalized);
    }
}