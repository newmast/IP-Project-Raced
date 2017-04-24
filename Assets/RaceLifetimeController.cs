using Assets;
using UnityEngine;
using UnityEngine.Networking;

public class RaceLifetimeController : NetworkBehaviour {

    private WinLoseDetector winLose;
    private int numberOfReadyPlayers;

    private void Start()
    {
        winLose = GameObject.FindGameObjectWithTag(Tags.WinLoseDetector).GetComponent<WinLoseDetector>();

        CmdNotifyReady();
    }

    [Command]
    public void CmdNotifyReady()
    {
        numberOfReadyPlayers++;
        if (numberOfReadyPlayers == 2)
        {
           RpcStart();
        }
    }

    [ClientRpc]
    public void RpcStart()
    {
        winLose.StartGame();
    }
}
