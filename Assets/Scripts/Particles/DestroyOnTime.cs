using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyOnTime : MonoBehaviour
{
    float minTime = 2f;
    float maxTime = 3f;
    float destroyTime;
    float timePassed = 0;

    void Start()
    {
        destroyTime = Random.Range(minTime, maxTime);
    }

    void Update()
    {
        timePassed += Time.deltaTime;
        if (timePassed >= destroyTime)
        {
            Destroy(gameObject);
        }
    }
}