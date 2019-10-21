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

    public GameObject trainPrefab;
    public GameObject lightObj;

    public float startDelay;

    void Awake()
    {
        startDelay = Random.Range(0f, trainLoopTime);
        randomSpawnPoint = Random.Range(0, 2);
    }

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
        GameObject car = Instantiate(trainPrefab, trainSpawnPoints[randomSpawnPoint].position, trainSpawnPoints[randomSpawnPoint].rotation);
        car.transform.SetParent(track);
        car.GetComponent<TrainManager>().speed = trainSpeed;
        car.GetComponent<TrainManager>().maxX = trainSpawnPoints[0].position.x;
        startDelay = 0f;
        StartCoroutine(FlashLight());
    }

    private bool ShouldSpawn()
    {
        return startDelay >= trainLoopTime;
    }

    IEnumerator FlashLight()
    {
        lightObj.SetActive(true);
        yield return new WaitForSeconds(.25f);
        lightObj.SetActive(false);
        yield return new WaitForSeconds(.25f);
        lightObj.SetActive(true);
        yield return new WaitForSeconds(.25f);
        lightObj.SetActive(false);
        yield return new WaitForSeconds(.25f);
        lightObj.SetActive(true);
        yield return new WaitForSeconds(.25f);
        lightObj.SetActive(false);
        yield return new WaitForSeconds(.25f);
        lightObj.SetActive(true);
        yield return new WaitForSeconds(.25f);
        lightObj.SetActive(false);
        yield return new WaitForSeconds(.25f);
        yield return null;
    }
}
