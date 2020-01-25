using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    float smoothSpeed = 1f;
    public Vector3 cameraOffset;
    [HideInInspector]
    public Transform target;
    // Update is called once per frame
    void FixedUpdate()
    {
        if (target == null)
            return;
        Vector3 desiredPosition = target.position + cameraOffset;
        Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed * Time.deltaTime);
        transform.position = smoothedPosition;
    }
}