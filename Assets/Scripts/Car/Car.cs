 using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(InputManager))]
public class Car : MonoBehaviour
{
    public Transform centerOfMass;

    public List<WheelCollider> steeringWheels;
    public List<WheelCollider> throttleWheels;
    public List<Transform> frontWheels;
    public List<Transform> rearWheels;
    public InputManager inputManager;
    [SerializeField]
    private float motorTorque = 500f;
    [SerializeField]
    private float maxSteering = 20f;
    private Rigidbody _rigitBody;

    // Start is called before the first frame update
    void Start()
    {
        inputManager = GetComponent<InputManager>();
        _rigitBody = GetComponent<Rigidbody>();
        _rigitBody.centerOfMass = centerOfMass.localPosition;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        foreach (var wheel in steeringWheels)
        {
            wheel.steerAngle = inputManager.steering * maxSteering ;
        }

        foreach (var wheel in throttleWheels)
        {
            wheel.motorTorque = motorTorque * inputManager.throttle;
        }
    }

    private void Update()
    {
        float wheelOffset = .15f;
        var pos = Vector3.zero;
        var rot = Quaternion.identity;

        for (int i = 0; i < throttleWheels.Count; i++)
        {
            throttleWheels[i].GetWorldPose(out pos, out rot);

            pos.x = i == 1 ? pos.x - wheelOffset : pos.x + wheelOffset;
            rearWheels[i].position = pos;
            rot = i == 1 ? rot : rot * Quaternion.Euler(0, 180, 0);
            rearWheels[i].rotation = rot;
        }

        for (int i = 0; i < steeringWheels.Count; i++)
        {
            steeringWheels[i].GetWorldPose(out pos, out rot);
            
            pos.x = i == 1 ? pos.x - wheelOffset : pos.x + wheelOffset;
            frontWheels[i].position = pos;
            rot = i == 1 ? rot : rot * Quaternion.Euler(0, 180, 0);
            frontWheels[i].rotation = rot;
        }
    }
}
