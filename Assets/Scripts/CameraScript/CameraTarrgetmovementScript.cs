using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraTarrgetmovementScript : MonoBehaviour
{
    public GameObject player;
    public float speed;
    public float offset;
    public float horizontalOffset;
    // Start is called before the first frame update

    // Update is called once per frame
    private void FixedUpdate()
    {
        Vector3 newPosition = transform.position;
        newPosition.x = player.transform.position.x + horizontalOffset;
        newPosition += (transform.forward * speed * Time.deltaTime);
        transform.position = newPosition;
        if(transform.position.z < player.transform.position.z)
        {
            newPosition.z = player.transform.position.z + offset;
            transform.position = newPosition;
        }
    }
}
