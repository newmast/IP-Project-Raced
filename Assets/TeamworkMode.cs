namespace Assets
{
    using Asset;
    using System.Collections.Generic;
    using UnityEngine;
    using UnityEngine.Networking;

    public class TeamworkMode : NetworkBehaviour, IObstacleProvider, ICoinGathering
    {
        private WinLoseDetector winLose;

        [SyncVar]
        private int coinPile;

        private void Awake()
        {
            AllowedObstacles = new List<string>() { "Coins1" };
        }

        private void Start()
        {
            winLose = GameObject.FindGameObjectWithTag(Tags.WinLoseDetector).GetComponent<WinLoseDetector>();
        }

        private void Update()
        {

        }

        public string DirectoryName
        {
            get { return "Coins"; }
        }

        public List<string> AllowedObstacles { get; private set; }

        public int NumberOfCoinPrefabsToSpawn
        {
            get { return 10; }
        }

        public void OnCoinMissed()
        {
            // Lose game
        }

        public void AddCoinsToTotalPile(int numberOfCoins)
        {
            coinPile += numberOfCoins;
        }

        public void OnCoinTaken(GameObject car, GameObject coin)
        {
            coinPile--;

            var raceController = car.GetComponent<RaceLifetimeController>();
            raceController.OnCoinTaken(coin);
        }

    }
}