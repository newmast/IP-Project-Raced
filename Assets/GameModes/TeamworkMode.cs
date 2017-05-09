namespace Assets
{
    using Asset;
    using System.Collections.Generic;
    using System.Linq;
    using UnityEngine;
    using UnityEngine.Networking;

    public class TeamworkMode : NetworkBehaviour, IObstacleProvider, ICoinGathering
    {
        [SyncVar]
        private int coinPile;

        private WinLoseDetector winLose;
        private bool gameEnded;

        private void Awake()
        {
            AllowedObstacles = new List<string>() { "Coins1" };
            NumberOfCoinPrefabsToSpawn = 10;
        }

        private void Start()
        {
            winLose = GameObject.FindGameObjectWithTag(Tags.WinLoseDetector).GetComponent<WinLoseDetector>();
        }

        private void Update()
        {
            if (NumberOfCoinPrefabsToSpawn <= 0 && !gameEnded)
            {
                gameEnded = true;
                winLose.EndGame(null);
            }
        }

        public string DirectoryName
        {
            get { return "Coins"; }
        }

        public List<string> AllowedObstacles { get; private set; }

        public int NumberOfCoinPrefabsToSpawn { get; set; }

        public void OnCoinMissed()
        {
            winLose.EndGame(GameObject.FindGameObjectsWithTag("Player").ToList());
        }

        public void AddCoinsToTotalPile(int numberOfCoins)
        {
            coinPile += numberOfCoins;
        }

        public void OnCoinTaken(GameObject car, GameObject coin)
        {
            var raceController = car.GetComponent<RaceLifetimeController>();
            raceController.OnCoinTaken(coin);

            coinPile--;
        }
    }
}