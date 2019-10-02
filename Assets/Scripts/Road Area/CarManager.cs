using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarManager : MonoBehaviour
{
    public bool carDrivingRight;

 

    void Update()
    {
        if (carDrivingRight == true)
        {
            transform.position += transform.up * Time.deltaTime;
        }
        else
        {
            transform.position -= transform.up * Time.deltaTime;

        }

        if (this.transform.position.x >= 10 || this.transform.position.x <= -10)
        {
            DeSpawn();
        }
    }

   private void DeSpawn()
    {
        Destroy(this.gameObject);
    }
}
