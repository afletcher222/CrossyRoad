using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrainSpawner : MonoBehaviour
{
    public float trainSpawnTime;

    public Transform track;
    public Transform[] trainSpawnPoints = new Transform[2];

    public int randomSpawnPoint;
    public int trainSpeed;
    public int carSpawnRandom;

    public GameObject trainPrefab;
    public GameObject roadLines;

    float timeDelay = 0f;

    void Awake()
    {
        randomSpawnPoint = Random.Range(0, 2);
        carSpawnRandom = Random.Range(1, 4);
    }

    // Update is called once per frame
    void Update()
    {
        timeDelay += Time.deltaTime;
        if (ShouldSpawn())
        {
            Spawn();
        }
    }

    private void Spawn()
    {
        trainSpawnTime = Time.time;
        GameObject car = Instantiate(trainPrefab, trainSpawnPoints[randomSpawnPoint].position, trainSpawnPoints[randomSpawnPoint].rotation);
        car.transform.SetParent(track);
        car.GetComponent<CarManager>().randomSpeed = trainSpeed + 3;
    }

    private bool ShouldSpawn()
    {
        return Time.deltaTime >= trainSpawnTime;
    }
}
