namespace Assets
{
    using UnityEngine;
    using UnityEngine.Networking;

    public class MyNetworkManager : NetworkManager
    {
        public override void OnServerAddPlayer(NetworkConnection conn, short playerControllerId)
        {
            //GameObject
            //    .FindGameObjectWithTag(Tags.WinLoseDetector)
            //    .GetComponent<WinLoseDetector>()
            //    .RpcWaitForReady();

            //base.OnServerAddPlayer(conn, playerControllerId);
            Debug.LogError("asdasdas");
        }
    }
}
