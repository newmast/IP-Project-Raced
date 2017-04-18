namespace Assets
{
    using System;
    using UnityEngine;
    using UnityEngine.Networking;
    using UnityEngine.SceneManagement;

    public class WinLoseDetector : NetworkBehaviour
    {
        [SerializeField]
        private CanvasGroup start;

        [SerializeField]
        private CanvasGroup end;

        private bool gameStart;
        private bool gameOver;

        public void Start()
        {
            start.alpha = 1;
            gameStart = true;
        }

        public override void OnStartClient()
        {
            Debug.LogError("clickding");
        }

        [ClientRpc]
        public void RpcWaitForReady()
        {
            start.alpha = 1;
            gameStart = true;
        }

        public void Update()
        {
            if (gameStart)
            {
                if (Input.GetKey(KeyCode.Space) || Input.touchCount > 0)
                {
                    start.alpha = 1;
                    gameStart = false;
                }
            }

            if (gameOver)
            {
                if (Input.GetKey(KeyCode.Space) || Input.touchCount > 0)
                {
                    PlayerPrefs.SetInt("ShowAd", PlayerPrefs.GetInt("ShowAd", 0) + 1);
                    if (PlayerPrefs.GetInt("ShowAd", 0) % 5 == 0)
                    {
                        AdController.ShowAd(() =>
                        {
                            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
                        });
                    }
                    else
                    {
                        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
                    }
                }
            }
        }

        [Command]
        private void CmdNotifyReady()
        {
            numberOfReadyPlayers++;
            RpcStartGameForEveryone();
        }

        [SyncVar]
        private int numberOfReadyPlayers;

        [ClientRpc]
        private void RpcStartGameForEveryone()
        {
            if (numberOfReadyPlayers == 2 && gameStart)
            {
                start.alpha = 0;
                gameStart = false;
            }
        }

        public void Lose()
        {
            end.alpha = 1;
            gameOver = true;
        }
    }
}