using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LogBehaviour : MonoBehaviour
{
    public GameObject logPrefab;

    public float speed;
    public int maxLogs;
    public bool floatLeft;
    public float maxX, minX;
    public Vector3 testWorld, testLocal;

    void Awake()
    {
        int logCount = Random.Range(2, maxLogs + 1);
        for (int x = logCount; x > 1; x--)
        {
            GameObject log = Instantiate(logPrefab, this.transform);
            Vector3 newPos = Vector3.zero;
            newPos.x += (x - 1);
            log.transform.localPosition = newPos;
            log.transform.rotation = Quaternion.Euler(Vector3.zero);
        }
    }

    void Update()
    {
        Vector3 newPos = transform.position;
        if (!floatLeft)
        {
            if (newPos.x > maxX)
            {
                newPos.x = minX;
            }
            newPos.x += Time.deltaTime * speed;
        }
        else
        {
            if (newPos.x < minX)
            {
                newPos.x = maxX;
            }
            newPos.x -= Time.deltaTime * speed;
        }
        transform.position = newPos;
    }
}