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

    public void OnCoinTaken(GameObject coin)
    {
        var netId = coin.GetComponent<NetworkIdentity>().netId;
        if (isServer)
        {
            RpcDestroyCoin(netId);
        }
        else
        {
            CmdOnCoinTaken(netId);
        }
    }

    [Command]
    public void CmdOnCoinTaken(NetworkInstanceId id)
    {
        RpcDestroyCoin(id);
    }

    [ClientRpc]
    public void RpcDestroyCoin(NetworkInstanceId id)
    {
        var coin = ClientScene.FindLocalObject(id);
        Destroy(coin);
    }
}
