namespace Assets
{
    using UnityEngine;
    using UnityEngine.Networking;
    
    public class ObstacleSpawner : NetworkBehaviour
    {
        [SerializeField]
        private Transform scorePointPrefab;
        
        private static string[] ObstacleIds = { "Obstacle1", "Obstacle2" };

        private Transform target;
        private WinLoseDetector winLoseDetector;

        public override void OnStartServer()
        {
            target = GameObject.FindGameObjectWithTag(Tags.CameraTarget).transform;
            winLoseDetector = GameObject.FindGameObjectWithTag(Tags.WinLoseDetector).GetComponent<WinLoseDetector>();

            InvokeRepeating("RpcSpawnObstacles", 3, 3);
        }
        
        [ClientRpc]
        private void RpcSpawnObstacles()
        {
            var position = target.position;
            position.z += Constants.RoadLength;

            var obstacle = Instantiate(
                Resources.Load("Obstacles/" + ObstacleIds[Random.Range(0, ObstacleIds.Length)]),
                position,
                Quaternion.identity) as GameObject;
            
            var scoreObject = Instantiate(scorePointPrefab.gameObject, position, Quaternion.identity) as GameObject;

            NetworkServer.Spawn(obstacle);
            NetworkServer.Spawn(scoreObject);
        }
    }
}
