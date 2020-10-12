using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraManager : MonoBehaviour
{
    public GameObject focus;
    public float distance = 5f;
    public float height = 2f;
    public float damping = 1f;

    // Update is called once per frame
    void Update()
    {
        var offset = focus.transform.TransformDirection(new Vector3(0f, height, -distance));
        transform.position = Vector3.Lerp(transform.position, focus.transform.position + offset, Time.deltaTime);
        transform.LookAt(focus.transform);
    }
}
