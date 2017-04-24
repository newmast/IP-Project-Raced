namespace Assets
{
    using UnityEngine;
    using UnityEngine.Networking;
    using UnityEngine.SceneManagement;

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

        public void EndGame()
        {
            shouldStartGame = false;
            shouldEndGame = true;
            end.alpha = 1;
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