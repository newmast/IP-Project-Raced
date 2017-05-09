namespace Assets
{
    using Asset;
    using UnityEngine;
    using UnityEngine.Networking;

    public class CoinSpawner : NetworkBehaviour
    {
        private Transform target;
        private WinLoseDetector winLoseDetector;
        private IObstacleProvider obstacleProvider;
        private ICoinGathering coinGathering;

        private int numberOfSpawnedObstacles;

        public void Start()
        {
            target = GameObject.FindGameObjectWithTag(Tags.CameraTarget).transform;
            winLoseDetector = GameObject.FindGameObjectWithTag(Tags.WinLoseDetector).GetComponent<WinLoseDetector>();

            var gamemode = GameObject.FindGameObjectWithTag(Tags.GameMode);
            obstacleProvider = gamemode.GetComponent<IObstacleProvider>();
            coinGathering = gamemode.GetComponent<ICoinGathering>();

            InvokeRepeating("RpcSpawnObstacles", 3, 3);
        }

        [ClientRpc]
        private void RpcSpawnObstacles()
        {
            if (--coinGathering.NumberOfCoinPrefabsToSpawn <= 0)
            {
                return;
            }

            var position = target.position;
            position.z += Constants.RoadLength;

            int randomObstacleIndex = Random.Range(0, obstacleProvider.AllowedObstacles.Count);

            var coinPlaceholder = Instantiate(
                Resources.Load(obstacleProvider.DirectoryName + "/" + obstacleProvider.AllowedObstacles[randomObstacleIndex]),
                position,
                Quaternion.identity) as GameObject;

            NetworkServer.Spawn(coinPlaceholder);
        }
    }
}
