using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaterTileManager : MonoBehaviour
{
    // General vars
    public float padLogRate;

    // Log vars
    public GameObject logPrefab;
    public Vector3 logSpawn1, logSpawn2, logSpawn3;

    // Pad vars
    public GameObject padPrefab;
    public List<Transform> padAbsoluteSpawn, padPossibleSpawn;
    public float padSpawnRate, padSinkDelay; // After sink delay, set rb.kinematic to false

    /*
    private void Awake()
    {
        if (Random.value < padLogRate)
        {
            bool floatLeft = (Random.value < .5f);
            GameObject log = Instantiate(logPrefab, this.transform);
            log.GetComponent<LogBehaviour>().leadLog = true;
            log.GetComponent<LogBehaviour>().floatLeft = floatLeft;
            log.transform.localPosition = logSpawn1;
            log = Instantiate(logPrefab, this.transform);
            log.GetComponent<LogBehaviour>().leadLog = true;
            log.GetComponent<LogBehaviour>().floatLeft = floatLeft;
            log.transform.localPosition = logSpawn2;
            log = Instantiate(logPrefab, this.transform);
            log.GetComponent<LogBehaviour>().leadLog = true;
            log.GetComponent<LogBehaviour>().floatLeft = floatLeft;
            log.transform.localPosition = logSpawn3;
        }
        else
        {
            foreach (Transform x in padAbsoluteSpawn)
            {
                Instantiate(padPrefab, x);
            }
            foreach (Transform x in padPossibleSpawn)
            {
                if (Random.value < padSpawnRate)
                {
                    Instantiate(padPrefab, x);
                }
            }
        }
    }
    */

}