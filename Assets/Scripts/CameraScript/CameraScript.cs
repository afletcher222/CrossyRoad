using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraScript : MonoBehaviour
{
    public Transform target;

    public float smoothTime = 0.3f;


    public Vector3 velocity = Vector3.zero;

    // Update is called once per frame
    void LateUpdate()
    {
        Vector3 pos = target.position;
        pos.y = transform.position.y;
        transform.position = Vector3.SmoothDamp(transform.position, pos, ref velocity, smoothTime);

    }
}
