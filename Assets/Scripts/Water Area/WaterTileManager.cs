using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaterTileManager : MonoBehaviour
{
    // General vars
    public float padLogRate;

    // Log vars
    public GameObject logPrefab;
    public List<Vector3> logSpawns;
    public float speedMin, speedMax;
    public GameObject locationDisable;

    // Pad vars
    public GameObject padPrefab;
    public List<Transform> padAbsoluteSpawn, padPossibleSpawn;
    public float padSpawnRate, padSinkDelay;

    private void Awake()
    {
        if (Random.value < padLogRate)
        {
            locationDisable.SetActive(false);
            bool floatLeft = (Random.value < .5f);
            float speed = Random.Range(speedMin, speedMax);
            GameObject log = null;
            foreach (Vector3 x in logSpawns)
            {
                log = Instantiate(logPrefab, this.transform);
                log.GetComponent<LogBehaviour>().floatLeft = floatLeft;
                log.GetComponent<LogBehaviour>().speed = speed;
                log.transform.localPosition = x;
            }
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
}