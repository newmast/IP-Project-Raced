namespace Assets
{
    using Asset;
    using UnityEngine;
    using UnityEngine.Networking;

    public class ObstacleSpawner : NetworkBehaviour
    {
        [SerializeField]
        private Transform scorePointPrefab;
        
        private Transform target;
        private WinLoseDetector winLoseDetector;
        private IObstacleProvider obstacleProvider;

        public void Start()
        {
            target = GameObject.FindGameObjectWithTag(Tags.CameraTarget).transform;
            winLoseDetector = GameObject.FindGameObjectWithTag(Tags.WinLoseDetector).GetComponent<WinLoseDetector>();
            obstacleProvider = GameObject.FindGameObjectWithTag(Tags.GameMode).GetComponent<IObstacleProvider>();

            InvokeRepeating("RpcSpawnObstacles", 3, 3);
        }
        
        [ClientRpc]
        private void RpcSpawnObstacles()
        {
            var position = target.position;
            position.z += Constants.RoadLength * 2;

            int randomObstacleIndex = Random.Range(0, obstacleProvider.AllowedObstacles.Count);

            var obstacle = Instantiate(
                Resources.Load(obstacleProvider.DirectoryName + "/" + obstacleProvider.AllowedObstacles[randomObstacleIndex]),
                position,
                Quaternion.identity) as GameObject;
            
            var scoreObject = Instantiate(scorePointPrefab.gameObject, position, Quaternion.identity) as GameObject;

            NetworkServer.Spawn(obstacle);
            NetworkServer.Spawn(scoreObject);
        }

        public Transform ScorePointPrefab
        {
            get { return scorePointPrefab; }
            set { scorePointPrefab = value; }
        }
    }
}