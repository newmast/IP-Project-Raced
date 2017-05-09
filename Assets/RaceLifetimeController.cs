using Assets;
using Assets.GameModes;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.SceneManagement;

public class RaceLifetimeController : NetworkBehaviour
{
    private WinLoseDetector winLose;
    private int numberOfReadyPlayers;

    private void Start()
    {
        winLose = GameObject.FindGameObjectWithTag(Tags.WinLoseDetector).GetComponent<WinLoseDetector>();

        CmdNotifyReady();
    }

    private void Update()
    {
        if (Input.GetKeyUp(KeyCode.R))
        {
            CmdRestart();
        }
    }

    [Command]
    public void CmdRestart()
    {
        RpcRestart();
    }

    [ClientRpc]
    public void RpcRestart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    [Command]
    public void CmdNotifyReady()
    {
        numberOfReadyPlayers++;
        if (GameObject.FindGameObjectWithTag(Tags.GameMode).GetComponent<GameModeHUD>().GameMode == GameMode.Singleplayer)
        {
            RpcStart();
        }
        else if (numberOfReadyPlayers == 2)
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
        var netId = coin.transform.parent.GetComponent<NetworkIdentity>().netId;
        if (isServer)
        {
            RpcDestroyCoin(netId, coin.transform.GetSiblingIndex());
        }
        else
        {
            CmdOnCoinTaken(netId, coin.transform.GetSiblingIndex());
        }
    }

    [Command]
    public void CmdOnCoinTaken(NetworkInstanceId id, int siblingIndex)
    {
        RpcDestroyCoin(id, siblingIndex);
    }

    [ClientRpc]
    public void RpcDestroyCoin(NetworkInstanceId id, int siblingIndex)
    {
        var coinGroup = ClientScene.FindLocalObject(id);
        var coinObject = coinGroup.transform.GetChild(siblingIndex).gameObject;

        Destroy(coinObject);
    }

    public void CmdShowEndGameMenu(List<NetworkInstanceId> winners)
    {
    }
}
