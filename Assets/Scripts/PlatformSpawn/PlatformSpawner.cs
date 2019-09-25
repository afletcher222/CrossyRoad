using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformSpawner : MonoBehaviour
{
    public List<Transform> platformList;
    public int listCounter = 0;
    public int amountPooled = 10;

    public Transform grassPlatform;
    public Transform waterPlatform;
    public Transform roadPlatform;
    public Transform currentPlatform;
    public Transform platformParent;

    public Vector3 startLocation = new Vector3 (0,0,0);
    public Vector3 spawnLocation;

    public int numberOfPlatforms = 10;
    public int platformsToRemove = 0;
    public int removeAmount;


    // Start is called before the first frame update
    void Start()
    {
        platformList = new List<Transform>();
        removeAmount = 3;
        startLocation = spawnLocation;

        for (int i = 0; i < numberOfPlatforms; i++)
        {
            if (i > 0)
            {
                int random = Random.Range(1, 4);

                switch(random)
                {
                    case 1:
                        Transform grass = Instantiate(grassPlatform, spawnLocation, Quaternion.identity);
                        grass.SetParent(platformParent);
                        platformList.Add(grass);
                        listCounter++;
                        break;
                    case 2:
                        Transform water = Instantiate(waterPlatform, spawnLocation, Quaternion.identity);
                        water.SetParent(platformParent);
                        platformList.Add(water);
                        listCounter++;
                        break;
                    case 3:
                        Transform road = Instantiate(roadPlatform, spawnLocation, Quaternion.identity);
                        road.SetParent(platformParent);
                        platformList.Add(road);
                        listCounter++;
                        break;
                }

            }
            else if(i == 0)
            {
                Transform grass = Instantiate(grassPlatform, spawnLocation, Quaternion.identity);
                platformList.Add(grass);
                listCounter++;
            }
            spawnLocation.z++;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    public void EndlessSpawning()
    {
        for (int i = 0; i < 7; i++)
        {
                int random = Random.Range(1, 4);

                switch (random)
                {
                    case 1:
                        Transform grass = Instantiate(grassPlatform, spawnLocation, Quaternion.identity);
                        grass.SetParent(platformParent);
                        platformList.Add(grass);
                        listCounter++;
                        break;
                    case 2:
                        Transform water = Instantiate(waterPlatform, spawnLocation, Quaternion.identity);
                        water.SetParent(platformParent);
                        platformList.Add(water);
                        listCounter++;
                        break;
                    case 3:
                        Transform road = Instantiate(roadPlatform, spawnLocation, Quaternion.identity);
                        road.SetParent(platformParent);
                        platformList.Add(road);
                        listCounter++;
                        break;
                }
            spawnLocation.z++;
        }
    }

    public void EndlessDespawning()
    {
        for (int i = 0; i < removeAmount; i++)
        {
            Destroy(platformList[platformsToRemove].gameObject);
            platformList.Remove(platformList[platformsToRemove]);
        }

        removeAmount = 7;
    }
}



