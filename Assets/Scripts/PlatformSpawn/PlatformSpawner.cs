using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformSpawner : MonoBehaviour
{
    public List<Transform> platformList;

    public Transform grassPlatform;
    public Transform waterPlatform;
    public Transform roadPlatform;
    public Transform trainPlatform;
    public Transform currentPlatform;
    public Transform platformParent;

    public Vector3 startLocation = new Vector3 (0,0,0);
    public Vector3 spawnLocation;

    public int numberOfPlatforms = 14;
    public int platformsToRemove = 0;
    public int removeAmount;

    public bool roadLanes;


    // Start is called before the first frame update
    void Start()
    {
        platformList = new List<Transform>();
        removeAmount = 7;
        startLocation = spawnLocation;

        for (int i = 0; i < numberOfPlatforms; i++)
        {
            if (i > 0)
            {
                int random = Random.Range(1, 5);

                switch(random)
                {
                    case 1:
                        Transform grass = Instantiate(grassPlatform, spawnLocation, Quaternion.identity);
                        grass.SetParent(platformParent);
                        platformList.Add(grass);
                        roadLanes = false;
                        break;
                    case 2:
                        Transform water = Instantiate(waterPlatform, spawnLocation, Quaternion.identity);
                        water.SetParent(platformParent);
                        platformList.Add(water);
                        roadLanes = false;
                        break;
                    case 3:
                        Transform train = Instantiate(trainPlatform, spawnLocation, Quaternion.identity);
                        train.SetParent(platformParent);
                        platformList.Add(train);
                        roadLanes = false;
                        break;
                    case 4:
                        Transform road = Instantiate(roadPlatform, spawnLocation, Quaternion.identity);
                        road.SetParent(platformParent);
                        platformList.Add(road);
                        if(roadLanes == false)
                        {
                            roadLanes = true;
                        }
                        else if(roadLanes == true)
                        {
                            road.GetComponent<CarSpawner>().roadLines.SetActive(true);
                            print("atleast 2 roads");
                        }
                        break;
                }

            }
            else if(i == 0)
            {
                Transform grass = Instantiate(grassPlatform, spawnLocation, Quaternion.identity);
                grass.SetParent(platformParent);
                platformList.Add(grass);
                grass = Instantiate(grassPlatform, (spawnLocation - new Vector3(0,0,1)), Quaternion.identity);
                grass.SetParent(platformParent);
                platformList.Add(grass);
                grass = Instantiate(grassPlatform, (spawnLocation - new Vector3(0, 0, 2)), Quaternion.identity);
                grass.SetParent(platformParent);
                platformList.Add(grass);
                grass = Instantiate(grassPlatform, (spawnLocation - new Vector3(0, 0, 3)), Quaternion.identity);
                grass.SetParent(platformParent);
                platformList.Add(grass);
                grass = Instantiate(grassPlatform, (spawnLocation - new Vector3(0, 0, 4)), Quaternion.identity);
                grass.SetParent(platformParent);
                platformList.Add(grass);
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
                        roadLanes = false;
                        break;
                    case 2:
                        Transform water = Instantiate(waterPlatform, spawnLocation, Quaternion.identity);
                        water.SetParent(platformParent);
                        platformList.Add(water);
                        roadLanes = false;
                        break;
                    case 3:
                        Transform road = Instantiate(roadPlatform, spawnLocation, Quaternion.identity);
                        road.SetParent(platformParent);
                        platformList.Add(road);
                    if (roadLanes == false)
                    {
                        roadLanes = true;
                    }
                    else if (roadLanes == true)
                    {
                        road.GetComponent<CarSpawner>().roadLines.SetActive(true);
                        print("atleast 2 roads");
                    }
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
    }
}



