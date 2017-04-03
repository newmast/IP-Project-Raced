using Assets;
using UnityEngine;

public class DetectPassThrough : MonoBehaviour
{
    private ScoreManager scoreManager;

    public void Start()
    {
        scoreManager = GameObject.FindGameObjectWithTag(Tags.ScoreManager).GetComponent<ScoreManager>();
    }

    public void OnTriggerEnter(Collider other)
    {
        scoreManager.Add(5);
    }
}
