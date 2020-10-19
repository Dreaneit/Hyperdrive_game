using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraManager : MonoBehaviour
{
    public Transform focus;
    public Vector3 offset;
    public Vector3 eulerRotation;
    public float damper;

    private void Start()
    {
        transform.eulerAngles = eulerRotation;
    }

    // Update is called once per frame
    void Update()
    {
        if (focus == null)
            return;

        //var offset = focus.transform.TransformDirection(new Vector3(0f, height, -distance));
        transform.position = Vector3.Lerp(transform.position, focus.transform.position + offset, damper * Time.deltaTime);
        transform.LookAt(focus.transform);
    }
}
