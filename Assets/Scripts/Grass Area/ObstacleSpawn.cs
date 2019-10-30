using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleSpawn : MonoBehaviour
{
    public GameObject[] obstacles = new GameObject[4];
    public List<Transform> locations = new List<Transform>();
    public List<Transform> outsideLocations = new List<Transform>();

    void Awake()
    {
        int random = Random.Range(2, 5);

        for (int i = 0; i < random; i++)
        {
            int randomObstacles = Random.Range(0, (obstacles.Length - 1));
            int randomLocations = Random.Range(0, (locations.Count - 1));

            GameObject obstacle = Instantiate(obstacles[randomObstacles], locations[randomLocations].transform.position, locations[randomLocations].transform.rotation);
            obstacle.transform.parent = gameObject.transform;

            Destroy(locations[randomLocations].GetComponent<ParentLocation>());
            locations.Remove(locations[randomLocations]);
        }

        int randomSecond = Random.Range(6, 14);

        for (int i = 0; i < randomSecond; i++)
        {
            int randomObstacles = Random.Range(0, (obstacles.Length - 1));
            int randomLocations = Random.Range(0, (outsideLocations.Count - 1));

            if (i > 1)
            {
                GameObject obstacle = Instantiate(obstacles[randomObstacles], outsideLocations[randomLocations].transform.position, outsideLocations[randomLocations].transform.rotation);
                obstacle.transform.parent = gameObject.transform;
                Destroy(outsideLocations[randomLocations].GetComponent<ParentLocation>());
                outsideLocations.Remove(outsideLocations[randomLocations]);
            }
            else if( i <= 1)
            {
                GameObject obstacle = Instantiate(obstacles[randomObstacles], outsideLocations[i].transform.position, outsideLocations[i].transform.rotation);
                obstacle.transform.parent = gameObject.transform;

                if (i == 1)
                {
                    Destroy(outsideLocations[1].GetComponent<ParentLocation>());
                    outsideLocations.Remove(outsideLocations[1]);
                    Destroy(outsideLocations[0].GetComponent<ParentLocation>());
                    outsideLocations.Remove(outsideLocations[0]);
                }
            }
        }
    }
}