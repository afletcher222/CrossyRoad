using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LogBehaviour : MonoBehaviour
{
    public float speed;
    public int maxLogs;
    public bool floatLeft;

    void Start()
    {
        floatLeft = (Random.value < .5f);
    }

    void Update()
    {
        
    }
}