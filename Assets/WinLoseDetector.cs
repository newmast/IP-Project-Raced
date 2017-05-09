namespace Assets
{
    using System.Collections.Generic;
    using UnityEngine;
    using UnityEngine.Networking;
    using UnityEngine.SceneManagement;
    using UnityEngine.UI;
    public class WinLoseDetector : MonoBehaviour
    {
        [SerializeField]
        private CanvasGroup start;

        [SerializeField]
        private CanvasGroup end;

        private bool waitingToStart = true;
        private bool shouldStartGame;
        private bool shouldEndGame;

        public bool IsWaitingToStart() { return waitingToStart; }

        public bool HasGameStarted() { return shouldStartGame; }

        public bool HasGameEnded() { return shouldEndGame; }

        public void StartGame()
        {
            waitingToStart = false;
            shouldStartGame = true;
        }

        private void Win()
        {
            ShowEndGameScreen("WINNER");
        }

        private void Lose()
        {
            ShowEndGameScreen("LOSER");
        }

        public void EndGame(List<GameObject> losers)
        {
            var players = GameObject.FindGameObjectsWithTag("Player");

            var isLoser = false;
            if (losers != null)
            {
                foreach (var player in players)
                {
                    var index = player.transform.GetSiblingIndex();
                    isLoser = (losers.Contains(player) && player.GetComponent<NetworkIdentity>().isLocalPlayer);
                    if (isLoser)
                    {
                        break;
                    }
                }
            }

            if (isLoser)
            {
                Lose();
            }
            else
            {
                Win();
            }
        }

        private void ShowEndGameScreen(string text)
        {
            if (shouldEndGame) return;
            shouldStartGame = false;
            shouldEndGame = true;
            end.alpha = 1;

            var textField = end.GetComponent<Text>();
            textField.text = text;

            Invoke("RestartScene", 2);
        }

        private void RestartScene()
        {
            NetworkManager.Shutdown();
            Destroy(GameObject.FindGameObjectWithTag("GameModeSelect"));
            SceneManager.LoadScene("Scenes/main-menu");
        }

        public void Update()
        {

            if (waitingToStart)
            {
                start.alpha = 1;
            }

            if (shouldStartGame)
            {
                start.alpha = 0;
            }

            if (shouldEndGame)
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
    }
}