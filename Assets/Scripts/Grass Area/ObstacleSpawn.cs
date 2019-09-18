using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleSpawn : MonoBehaviour
{
    public GameObject[] obstacles = new GameObject[4];
    public List<ObstacleLocations> locations = new List<ObstacleLocations>();

    // Start is called before the first frame update
    void Awake()
    {
        int random = Random.Range(2, 5);

        GetComponentsInChildren<ObstacleLocations>(false, locations);

        for (int i = 0; i < random; i++)
        {
            int randomObstacles = Random.Range(1, obstacles.Length);
            int randomLocations = Random.Range(1, locations.Count);

            Instantiate(obstacles[randomObstacles], locations[randomLocations].transform.position, locations[randomLocations].transform.rotation);

            locations.Remove(locations[randomLocations]);

        }
    }

}
