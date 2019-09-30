using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaterTileManager : MonoBehaviour
{
    // General vars
    public float padLogRate;

    // Log vars
    public GameObject logPrefab;

    // Pad vars
    public GameObject padPrefab;
    public List<Transform> padAbsoluteSpawn, padPossibleSpawn;
    public float padSpawnRate, padSinkDelay; // After sink delay, set rb.kinematic to false

    private void Awake()
    {
        if (Random.value < padLogRate)
        {
            Instantiate(logPrefab, this.transform);
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