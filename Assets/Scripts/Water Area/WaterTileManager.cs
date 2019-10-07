using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaterTileManager : MonoBehaviour
{
        // General vars
    // Used to determine ratio of Log-tiles to Pad-tiles. 0 = all pad, 1 = all logs.
    public float padLogRate;

        // Log vars
    public GameObject logPrefab;
    // List of points where the logs will spawn
    public List<Vector3> logSpawns;
    public float speedMin, speedMax;
    // This is the Locations container in the water container prefab. Disable to prevent player snapping anywhere other than log.
    public GameObject locationDisable;

        // Pad vars
    public GameObject padPrefab;
    // Absolute spawn for the definite "always clear" path, possible for everything else
    public List<Transform> padAbsoluteSpawn, padPossibleSpawn;
    public float padSpawnRate, padSinkDelay; // Sink delay for unused sinking pad feature. After sink delay, set rb.kinematic to false

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