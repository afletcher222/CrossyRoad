﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrainManager : MonoBehaviour
{
    public bool trainGoingRight;
    public int speed;
    public float maxX;

    void Update()
    {
        if (trainGoingRight == true)
        {
            transform.position += (transform.up * speed * Time.deltaTime);
        }
        else
        {
            transform.position -= transform.up * speed * Time.deltaTime;

        }

        if (this.transform.position.x >= maxX || this.transform.position.x <= -maxX)
        {
            DeSpawn();
        }
    }

    private void DeSpawn()
    {
        Destroy(this.gameObject);
    }
}
