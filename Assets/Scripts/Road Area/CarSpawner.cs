using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarSpawner : MonoBehaviour
{
    public float carSpawnTime;

    public Transform road;
    public Transform[] carSpawnPoints = new Transform[2];

    public int randomSpawnPoint;
    public float randomCarSpeed;
    public int carSpawnRandom;

    public GameObject carNum01Prefab;
    public GameObject carNum02Prefab;
    public GameObject roadLines;
    public GameObject trainTracks;


     void Awake()
    {
        randomSpawnPoint = Random.Range(0, 2);
        randomCarSpeed = Random.value;
        carSpawnRandom = Random.Range(1, 4);
    }

    // Update is called once per frame
    void Update()
    {
        if (ShouldSpawn())
        {
            Spawn();
        }
    }

    private void Spawn()
    {
        int random = Random.Range(3, 8);
        
      

        if (carSpawnRandom >= 3)
        {
            carSpawnTime = Time.time + random;
            GameObject car = Instantiate(carNum01Prefab, carSpawnPoints[randomSpawnPoint].position, carSpawnPoints[randomSpawnPoint].rotation);
            car.transform.SetParent(road);
<<<<<<< HEAD
            car.GetComponent<CarManager>().randomSpeed = randomCarSpeed + 4f;
            //car.transform.LookAt();
=======
            car.GetComponent<CarManager>().randomSpeed = randomCarSpeed + 3;
>>>>>>> 86e52908fab2e5fc97b5eabf9fe892caf2b2f70c
        }
        if (carSpawnRandom < 3)
        {
            carSpawnTime = Time.time + random;
            GameObject car = Instantiate(carNum02Prefab, carSpawnPoints[randomSpawnPoint].position, carSpawnPoints[randomSpawnPoint].rotation);
            car.transform.SetParent(road);
<<<<<<< HEAD
            car.GetComponent<CarManager>().randomSpeed = randomCarSpeed + 2f;
            //car.transform.LookAt();
=======
            car.GetComponent<CarManager>().randomSpeed = randomCarSpeed+1;
>>>>>>> 86e52908fab2e5fc97b5eabf9fe892caf2b2f70c
        }
    }

    private bool ShouldSpawn()
    {
        return Time.time >= carSpawnTime;
    }
}
