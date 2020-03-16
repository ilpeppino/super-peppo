using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{

    private const float 
        XOFFSET = 0f,
        YOFFSET = 5f,
        ZOFFSET = -20f;

    public Transform target;

    public float smoothSpeed = 10f;
    public Vector3 offset;

    private void Awake()
    {
        offset = new Vector3(XOFFSET, YOFFSET, ZOFFSET);
    }

    void FixedUpdate()
    {
        // If i want to snap directly to the rocket
        // transform.position = target.position;

        // With an offset
        // transform.position = target.position + offset;

        Vector3 desiredCameraPosition = target.position + offset;

        // Lerp is linear interpolation from point a to point b over a certain time. The 3rd parameter is 0<t<1, where 0 is the 1st position, and 1 is the 2nd position
        Vector3 smoothedCameraPosition = Vector3.Lerp(transform.position, desiredCameraPosition, smoothSpeed * Time.deltaTime);
        transform.position = smoothedCameraPosition;

        transform.LookAt(target);
    }
}