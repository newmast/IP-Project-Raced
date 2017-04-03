namespace Assets
{
    using System.Collections.Generic;
    using UnityEngine;

    public class ObstacleSpawner : MonoBehaviour
    {
        private List<Transform> obstaclePrefabs;

        private Transform target;

        private void Start()
        {
            target = GameObject.FindGameObjectWithTag(Tags.CameraTarget).transform;
            obstaclePrefabs = new List<Transform>();
            Seed();
            InvokeRepeating("SpawnObstacle", 2, 2f);
        }

        private void Seed()
        {
            string[] paths = {"Obstacle1", "Obstacle2"};

            var obstacle = Instantiate(
                Resources.Load("Obstacles/" + paths[Random.Range(0, paths.Length)]),
                new Vector3(20, 0, 0),
                Quaternion.identity) as GameObject;

            obstaclePrefabs.Add(obstacle.transform);
        }

        private void SpawnObstacle()
        {
            var position = target.position;
            position.z += Constants.RoadLength;

            var selectedObstacle = obstaclePrefabs[Random.Range(0, obstaclePrefabs.Count)];

            selectedObstacle.position = position;
        }
    }
}
