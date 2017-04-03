namespace Assets
{
    using UnityEngine;

    public class GenerateTerrain : MonoBehaviour
    {
        [SerializeField]
        private Transform roadPrefab;

        [SerializeField]
        private Transform topGrass;

        [SerializeField]
        private Transform bottomGrass;

        private MoveForward target;
        private Vector3 lastSpawnedRoadPosition;
        private Vector3 lastSpawnedTopGrassPosition;
        private Vector3 lastSpawnedBottomGrassPosition;

        private Transform[] roadsPool;
        private Transform[] topGrassPool;
        private Transform[] bottomGrassPool;

        private void Start()
        {
            target = GameObject.FindGameObjectWithTag(Tags.CameraTarget).GetComponent<MoveForward>();

            roadsPool = new Transform[4];
            SeedPool(roadsPool, roadPrefab);

            topGrassPool = new Transform[6];
            SeedPool(topGrassPool, topGrass);

            bottomGrassPool = new Transform[6];
            SeedPool(bottomGrassPool, bottomGrass);
        }

        private void SeedPool(Transform[] pool, Transform prefab)
        {
            var pos = new Vector3(20, 0, 0);
            for (var i = 0; i < pool.Length; i++)
            {
                pool[i] = (Instantiate(prefab.gameObject, pos, Quaternion.identity) as GameObject).transform;
            }
        }

        private Transform GetLastInLine(Transform[] pool)
        {
            Transform lastInLine = pool[0].transform;
            for (var i = 1; i < pool.Length; i++)
            {
                var minZ = lastInLine.transform.position.z;
                var currentZ = pool[i].transform.position.z;

                if (currentZ < minZ)
                {
                    lastInLine = pool[i];
                }
            }

            return lastInLine;
        }

        private void Update()
        {
            SpawnIfAppropriate(roadsPool, ref lastSpawnedRoadPosition, Constants.RoadLength);

            lastSpawnedTopGrassPosition.x = Constants.RoadLength / 2f;
            SpawnIfAppropriate(topGrassPool, ref lastSpawnedTopGrassPosition, Constants.GrassWidth);

            lastSpawnedBottomGrassPosition.x = -lastSpawnedTopGrassPosition.x;
            SpawnIfAppropriate(bottomGrassPool, ref lastSpawnedBottomGrassPosition, Constants.GrassWidth);
        }

        private void SpawnIfAppropriate(Transform[] pool, ref Vector3 lastDistance, float prefabWidth)
        {
            var position = target.transform.position;

            if (lastDistance.z - Constants.RoadLength < position.z)
            {
                lastDistance.z += prefabWidth;
                var spawned = GetLastInLine(pool);
                spawned.position = lastDistance;
            }
        }
    }
}
