namespace Asset
{
    using System;
    using System.Collections.Generic;
    using Assets;
    using UnityEngine;
    using UnityEngine.Networking;

    public class SurvivalMode : NetworkBehaviour, ICarCrashListener, IObstacleProvider
    {
        private WinLoseDetector winLose;
        private CrashHandler crashHandler;

        private void Awake()
        {
            AllowedObstacles = new List<string> { "Obstacle1", "Obstacle2" };
        }

        private void Start()
        {
            winLose = GameObject.FindGameObjectWithTag(Tags.WinLoseDetector).GetComponent<WinLoseDetector>();
        }

        public string DirectoryName
        {
            get { return "Obstacles"; }
        }

        public List<string> AllowedObstacles { get; private set; }

        public void OnCarCrashed(GameObject car, GameObject rock)
        {
            car.GetComponent<MoveForward>().Speed = 0;
            GameObject.FindGameObjectWithTag(Tags.WinLoseDetector).GetComponent<WinLoseDetector>().EndGame();
        }
    }
}
