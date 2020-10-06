 using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(InputManager))]
public class Car : MonoBehaviour
{
    public List<WheelCollider> steeringWheels;
    public List<WheelCollider> throttleWheels;
    public InputManager inputManager;
    private float enginePower = 20000f;
    private float maxSteering = 20f;

    // Start is called before the first frame update
    void Start()
    {
        inputManager = GetComponent<InputManager>();
    }

    // Update is called once per frame
    void Update()
    {
        foreach (var wheel in steeringWheels)
        {
            wheel.steerAngle = inputManager.steering * maxSteering;
        }

        foreach (var wheel in throttleWheels)
        {
            wheel.motorTorque = enginePower * inputManager.throttle * Time.deltaTime;
        }
    }
}
