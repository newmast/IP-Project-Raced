using Asset;
using Assets;
using Assets.GameModes;
using UnityEngine;
using UnityEngine.Networking;

public class GameModeController : NetworkBehaviour
{
    [SerializeField]
    private Transform scorePoint;

    private GameModeHUD hud;
    
    public void UpdateGame(GameMode mode)
    {
        var gameMode = GameObject.FindGameObjectWithTag(Tags.GameMode);

        Destroy(gameMode.GetComponent<SurvivalMode>());
        Destroy(gameMode.GetComponent<ChaseMode>());
        Destroy(gameMode.GetComponent<TeamworkMode>());
        
        switch (mode)
        {
            case GameMode.Singleplayer:
            case GameMode.Survival:
                gameMode.AddComponent<SurvivalMode>();
                break;
            case GameMode.Chase:
                gameMode.AddComponent<ChaseMode>();
                break;
            case GameMode.Teamwork:
                gameMode.AddComponent<TeamworkMode>();
                break;
        }

        var spawner = GameObject.Find("Management/RoadItemSpawner");

        if (isServer)
        {
            Destroy(spawner.GetComponent<CoinSpawner>());
            Destroy(spawner.GetComponent<ObstacleSpawner>());

            switch (mode)
            {
                case GameMode.Singleplayer:
                case GameMode.Survival:
                case GameMode.Chase:
                    spawner.AddComponent<ObstacleSpawner>().ScorePointPrefab = scorePoint;
                    break;
                case GameMode.Teamwork:
                    spawner.AddComponent<CoinSpawner>();
                    break;
            }
        }
    }
}
