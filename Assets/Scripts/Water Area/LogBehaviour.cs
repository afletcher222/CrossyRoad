using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LogBehaviour : MonoBehaviour
{
    public bool leadLog = false;
    public GameObject logPrefab;
    public float speed;
    public int maxLogs;
    public bool floatLeft;
    public float maxX, minX;

    void Start()
    {
        int logCount = Random.Range(2, maxLogs + 1);
        while (logCount > 1)
        {
            GameObject log = Instantiate(logPrefab, this.transform);
            log.GetComponent<LogBehaviour>().floatLeft = floatLeft;
            Vector3 newPos = this.transform.position;
            newPos.x += logCount;
            log.transform.localPosition = newPos;

            logCount--;
        }
        
    }

    void Update()
    {
        if (leadLog)
        {
            Vector3 newPos = transform.position;
            if (floatLeft)
            {
                newPos.x += Time.deltaTime * speed;
            }
            else
            {
                newPos.x -= Time.deltaTime * speed;
            }
            transform.position = newPos;
        }
    }
}