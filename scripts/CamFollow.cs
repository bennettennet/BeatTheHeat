using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamFollow : MonoBehaviour
{
    //where the camera is trying to follow (the player)
    public Transform target;
    //how much to offset the target 
    public float offset;
    //how quickly it catches up
    public float smoothSpeed = 0.125f;

    void FixedUpdate()
    {
        //stuff to make camera follow nice and smooth
        float hPos = target.position.x;
        Vector3 desiredPosition = new Vector3(hPos, 0, offset);
        Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed);

        transform.position = smoothedPosition;
    }
}
