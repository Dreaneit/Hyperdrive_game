using UnityEngine;

public class Wheel : MonoBehaviour
{
    public bool steer, invertSteer, power, leftWheel, rightWheel;

    public float SteerAngle { get; set; }
    public float Torque { get; set; }

    private WheelCollider wheelCollider;
    private Transform wheelTransform;

    // Start is called before the first frame update
    void Start()
    {
        wheelCollider = GetComponentInChildren<WheelCollider>();
        wheelTransform = GetComponentInChildren<MeshRenderer>().GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        RotateWheels();
    }

    private void RotateWheels()
    {
        //float wheelOffset = .15f;
        wheelCollider.GetWorldPose(out Vector3 pos, out Quaternion rot);

        //pos.x = i == 1 ? pos.x - wheelOffset : pos.x + wheelOffset;
        wheelTransform.position = pos;
        
        if (leftWheel)
        {
            rot *= Quaternion.Euler(0, 180, 0);
        }

        wheelTransform.rotation = rot;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (steer)
        {
            wheelCollider.steerAngle = SteerAngle * (invertSteer ? -1 : 1);
        }

        if (power)
        {
            wheelCollider.motorTorque = Torque;
        }
    }
}
