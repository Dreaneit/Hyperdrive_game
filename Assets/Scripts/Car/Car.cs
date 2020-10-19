using UnityEngine;

public class Car : MonoBehaviour
{
    public Transform centerOfMass;
    private Rigidbody _rigitBody;
    private Wheel[] wheels;

    public float Steer { get; set; }
    public float Throttle { get; set; }

    [SerializeField]
    private float motorTorque = 500f;
    [SerializeField]
    private float maxSteering = 20f;

    // Start is called before the first frame update
    void Start()
    {
        _rigitBody = GetComponent<Rigidbody>();
        _rigitBody.centerOfMass = centerOfMass.localPosition;
        wheels = GetComponentsInChildren<Wheel>();
    }


    private void Update()
    {
        Steer = GameManager.Instance.InputController.SteeringInput;
        Throttle = GameManager.Instance.InputController.ThrottleInput;

        foreach (var wheel in wheels)
        {
            wheel.SteerAngle = Steer * maxSteering;
            wheel.Torque = Throttle * motorTorque;
        }
    }
}
