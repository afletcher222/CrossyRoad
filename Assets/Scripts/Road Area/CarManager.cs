using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarManager : MonoBehaviour
{
    public bool carDrivingRight;
    public  int randomSpeed;
 


    void Update()
    {
        if (carDrivingRight == true)
        {
            transform.position += (transform.up * randomSpeed * Time.deltaTime);
        }
        else
        {
            transform.position -= transform.up * randomSpeed * Time.deltaTime;

        }

        if (this.transform.position.x >= 13 || this.transform.position.x <= -13)
        {
            DeSpawn();
        }
    }

   private void DeSpawn()
    {
        Destroy(this.gameObject);
    }
}
