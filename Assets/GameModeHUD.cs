using Assets.GameModes;
using System;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;


public class GameModeHUD : NetworkBehaviour
{
    [SerializeField]
    private Button survivalMode;

    [SerializeField]
    private Button chaseMode;

    [SerializeField]
    private Button teamworkMode;

    private Component chosenGameMode;
    private Component chosenSpawner;

	public void Start()
    {
        var mode = GameObject.FindGameObjectWithTag("GameModeSelect").GetComponent<GameModeSelect>().GameMode;
        Debug.Log(mode);
        CmdSetGameMode(mode);
    }

    private void CmdSetGameMode(GameMode mode)
    {
        GameMode = mode;
        GetComponent<GameModeController>().UpdateGame(GameMode);
    }

    public GameMode GameMode { get; private set; }
}
