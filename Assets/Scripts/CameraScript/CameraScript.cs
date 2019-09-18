using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraScript : MonoBehaviour
{
    public Camera mainCamera;

    public Transform cameraLookTarget;

    // Start is called before the first frame update
    void Start()
    {
       // mainCamera.transform.LookAt(cameraLookTarget);
    }

    // Update is called once per frame
    void LateUpdate()
    {
       // mainCamera.transform.LookAt(cameraLookTarget);
    }
}
