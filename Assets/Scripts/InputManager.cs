using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager : MonoBehaviour
{
    public float ThrottleInput { get; private set; }
    public float SteeringInput { get; private set; }

    // Update is called once per frame
    void Update()
    {
        ThrottleInput = Input.GetAxis("Vertical");
        SteeringInput = Input.GetAxis("Horizontal");
    }
}
