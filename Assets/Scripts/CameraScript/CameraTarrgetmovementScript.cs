using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraTarrgetmovementScript : MonoBehaviour
{
    public GameObject playerCameraTarget;
    public float speed;
    public float offset;
    public PlayerMove player;
    Vector3 newPosition;
    // Start is called before the first frame update

    // Update is called once per frame
    private void FixedUpdate()
    {
        if (player.cameraMove > 3)
        {
            newPosition = transform.position;
            newPosition.x = playerCameraTarget.transform.position.x;
            newPosition += (transform.forward * speed * Time.deltaTime);
            transform.position = newPosition;
        }
        if(transform.position.z < playerCameraTarget.transform.position.z)
        {
            newPosition = transform.position;
            newPosition.z = playerCameraTarget.transform.position.z + offset;
            transform.position = newPosition;
        }
    }
}
