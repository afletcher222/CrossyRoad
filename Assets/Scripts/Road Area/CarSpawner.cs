﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarSpawner : MonoBehaviour
{
    public float carSpawnTime;

    public Transform road;
    public Transform[] carSpawnPoints = new Transform[2];

    public int randomSpawnPoint;
    public GameObject carNum01Prefab;

     void Awake()
    {
        randomSpawnPoint = Random.Range(0, 2);
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

        carSpawnTime = Time.time + random;
        //Instantiate(carNum01Prefab, transform.position, Quaternion.Euler(-90,90,0));
        GameObject car = Instantiate(carNum01Prefab, carSpawnPoints[randomSpawnPoint].position, carSpawnPoints[randomSpawnPoint].rotation);
        car.transform.SetParent(road);
        //car.transform.LookAt();
    }

    private bool ShouldSpawn()
    {
        return Time.time >= carSpawnTime;
    }
}
