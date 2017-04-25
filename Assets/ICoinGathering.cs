using UnityEngine;

namespace Assets
{
    public interface ICoinGathering
    {
        int NumberOfCoinPrefabsToSpawn { get; }

        void AddCoinsToTotalPile(int numberOfCoins);

        void OnCoinTaken(GameObject car, GameObject coin);

        void OnCoinMissed();
    }
}