using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamFollow : MonoBehaviour
{
    public Transform target;
    public float offset;
    public float smoothSpeed = 0.125f;

    void FixedUpdate()
    {
        float hPos = target.position.x;
        Vector3 desiredPosition = new Vector3(hPos, 0, offset);
        Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed);

        transform.position = smoothedPosition;
    }
}
