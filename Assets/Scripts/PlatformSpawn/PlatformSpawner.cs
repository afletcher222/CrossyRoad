using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformSpawner : MonoBehaviour
{
    public List<Transform> grassPlatformPool;
    public int grassCounter = 0;
    public List<Transform> waterPlatformPool;
    public int waterCounter = 0;
    public List<Transform> roadPlatformPool;
    public int roadCounter = 0;
    public int amountPooled;

    public Transform grassPlatform;
    public Transform waterPlatform;
    public Transform roadPlatform;
    public Transform currentPlatform;
    public Transform platformParent;

    public Vector3 startLocation = new Vector3 (0,0,0);
    public Vector3 spawnLocation;

    public int numberOfPlatforms = 10;


    // Start is called before the first frame update
    void Start()
    {
        grassPlatformPool = new List<Transform>();
        waterPlatformPool = new List<Transform>();
        roadPlatformPool = new List<Transform>();

        for (int i = 0; i < amountPooled; i++)
        {
            Transform platform = (Transform)Instantiate(grassPlatform);
            platform.gameObject.SetActive(false);
            platform.SetParent(platformParent);
            grassPlatformPool.Add(platform);
        }
        for (int i = 0; i < amountPooled; i++)
        {
            Transform platform = (Transform)Instantiate(waterPlatform);
            platform.gameObject.SetActive(false);
            platform.SetParent(platformParent);
            waterPlatformPool.Add(platform);
        }
        for (int i = 0; i < amountPooled; i++)
        {
            Transform platform = (Transform)Instantiate(roadPlatform);
            platform.gameObject.SetActive(false);
            platform.SetParent(platformParent);
            roadPlatformPool.Add(platform);
        }


        startLocation = spawnLocation;
        for (int i = 0; i < numberOfPlatforms; i++)
        {
            if (i > 0)
            {
                int random = Random.Range(1, 4);

                switch(random)
                {
                    case 1:
                        grassPlatformPool[grassCounter].position = spawnLocation;
                        grassPlatformPool[grassCounter].gameObject.SetActive(true);
                        grassCounter++;
                            if(grassCounter > 9)
                        {
                            grassCounter = 1;
                        }
                        break;
                    case 2:
                        waterPlatformPool[waterCounter].position = spawnLocation;
                        waterPlatformPool[waterCounter].gameObject.SetActive(true);
                        waterCounter++;
                        if (waterCounter > 9)
                        {
                            waterCounter = 0;
                        }
                        break;
                    case 3:
                        roadPlatformPool[roadCounter].position = spawnLocation;
                        roadPlatformPool[roadCounter].gameObject.SetActive(true);
                        roadCounter++;
                        if (roadCounter > 9)
                        {
                            roadCounter = 0;
                        }
                        break;

                }

            }
            else if(i == 0)
            {
                grassPlatformPool[grassCounter].position = spawnLocation;
                grassPlatformPool[grassCounter].gameObject.SetActive(true);
                grassCounter++;
            }
            spawnLocation.z++;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }



}
