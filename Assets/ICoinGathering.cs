namespace Assets
{
    public interface ICoinGathering
    {
        int NumberOfCoinPrefabsToSpawn { get; }

        void AddCoinsToTotalPile(int numberOfCoins);

        void OnCoinTaken();

        void OnCoinMissed();
    }
}