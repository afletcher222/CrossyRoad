using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleSpawn : MonoBehaviour
{
    public GameObject[] obstacles = new GameObject[4];
    public List<ObstacleLocations> locations = new List<ObstacleLocations>();
    public List<ObstacleLocations> outsideLocations = new List<ObstacleLocations>();

    // Start is called before the first frame update
    void Awake()
    {
        int random = Random.Range(2, 5);

        GetComponentsInChildren<ObstacleLocations>(false, locations);

        for (int i = 0; i < random; i++)
        {
            int randomObstacles = Random.Range(0, (obstacles.Length - 1));
            int randomLocations = Random.Range(0, (locations.Count - 1));

            GameObject obstacle = Instantiate(obstacles[randomObstacles], locations[randomLocations].transform.position, locations[randomLocations].transform.rotation);
            obstacle.transform.parent = gameObject.transform;

            Destroy(locations[randomLocations].GetComponent<ParentLocation>());
            locations.Remove(locations[randomLocations]);

        }

        random = Random.Range(6, 14);

        for (int i = 0; i < random; i++)
        {
            int randomObstacles = Random.Range(0, (obstacles.Length - 1));
            int randomLocations = Random.Range(0, (outsideLocations.Count - 1));

            if (i > 1)
            {
                GameObject obstacle = Instantiate(obstacles[randomObstacles], locations[randomLocations].transform.position, locations[randomLocations].transform.rotation);
                obstacle.transform.parent = gameObject.transform;
                Destroy(locations[randomLocations].GetComponent<ParentLocation>());
                locations.Remove(locations[randomLocations]);
            }
            else if( i <= 1)
            {
                GameObject obstacle = Instantiate(obstacles[randomObstacles], outsideLocations[i].transform.position, outsideLocations[i].transform.rotation);
                obstacle.transform.parent = gameObject.transform;
                Destroy(outsideLocations[i].GetComponent<ParentLocation>());
                locations.Remove(outsideLocations[i]);
            }

        }
    }

}
