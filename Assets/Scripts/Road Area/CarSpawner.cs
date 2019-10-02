using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarSpawner : MonoBehaviour
{
    public float carSpawnTime;
    

    public GameObject carNum01Prefab;

    

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
        int random = Random.Range(2, 5);

        carSpawnTime = Time.time + random;
        Instantiate(carNum01Prefab, transform.position, Quaternion.Euler(-90,90,0));
        
    }

    private bool ShouldSpawn()
    {
        return Time.time >= carSpawnTime;
    }
}
