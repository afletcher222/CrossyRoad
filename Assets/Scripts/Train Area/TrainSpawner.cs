using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrainSpawner : MonoBehaviour
{
    public float trainLoopTime;

    public Transform track;
    public Transform[] trainSpawnPoints = new Transform[2];

    public int randomSpawnPoint;
    public int trainSpeed;
    //public int carSpawnRandom;

    public GameObject trainPrefab;
    //public GameObject roadLines;

    public float startDelay;

    void Awake()
    {
        startDelay = Random.Range(0f, trainLoopTime);
        randomSpawnPoint = Random.Range(0, 2);
        //carSpawnRandom = Random.Range(1, 4);
    }

    // Update is called once per frame
    void Update()
    {
        startDelay += Time.deltaTime;
        if (ShouldSpawn())
        {
            Spawn();
        }
    }

    private void Spawn()
    {
        //trainLoopTime = Time.time;
        GameObject car = Instantiate(trainPrefab, trainSpawnPoints[randomSpawnPoint].position, trainSpawnPoints[randomSpawnPoint].rotation);
        car.transform.SetParent(track);
        car.GetComponent<TrainManager>().speed = trainSpeed;
        car.GetComponent<TrainManager>().maxX = trainSpawnPoints[0].position.x;
        startDelay = 0f;
    }

    private bool ShouldSpawn()
    {
        return startDelay >= trainLoopTime;
    }
}
