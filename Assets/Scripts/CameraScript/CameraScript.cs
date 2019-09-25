using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraScript : MonoBehaviour
{
    public Transform target;

    public float smoothTime = 0.3f;

<<<<<<< HEAD
    public Vector3 velocity = Vector3.zero;
=======
    // Start is called before the first frame update
    void Start()
    {
       //mainCamera.transform.LookAt(cameraLookTarget);
    }
>>>>>>> fc52f16afa7d864e2ed1fe7cee78d7e87fe33e6a

    // Update is called once per frame
    void LateUpdate()
    {
<<<<<<< HEAD
        Vector3 pos = target.position;
        pos.y = transform.position.y;
        transform.position = Vector3.SmoothDamp(transform.position, pos, ref velocity, smoothTime);
=======
      // mainCamera.transform.LookAt(cameraLookTarget);
>>>>>>> fc52f16afa7d864e2ed1fe7cee78d7e87fe33e6a
    }
}
