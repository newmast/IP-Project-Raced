using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{
    [SerializeField]
    private Text scoreText;

    private int currentScore;

    public void Start()
    {
        scoreText.text = "0";
    }

    public void Add(int score)
    {
        currentScore += score;
        scoreText.text = "" + currentScore;
    }
}
