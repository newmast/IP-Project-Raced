namespace Assets
{
    using UnityEngine;
    using UnityEngine.SceneManagement;

    public class WinLoseDetector : MonoBehaviour
    {
        [SerializeField] private CanvasGroup start;
        [SerializeField] private CanvasGroup end;

        private bool gameStart;
        private bool gameOver;

        public void Start()
        {
            Time.timeScale = 0;
            start.alpha = 1;
            gameStart = true;
        }

        public void Update()
        {
            if (gameStart)
            {
                if (Input.GetKey(KeyCode.Space) || Input.touchCount > 0)
                {
                    start.alpha = 0;
                    Time.timeScale = 1;
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

        public void Lose()
        {
            end.alpha = 1;
            Time.timeScale = 0;
            gameOver = true;
        }
    }
}
