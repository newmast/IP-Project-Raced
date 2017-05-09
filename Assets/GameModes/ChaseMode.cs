using Asset;
using Assets;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class ChaseMode : NetworkBehaviour, ICarCrashListener, IObstacleProvider
{
    private const float EscapeeWinDistance = 10f;
    private WinLoseDetector winLose;
    private Transform target;

    private bool hasInitialized;
    private MoveForward moveForward;
    private bool gameEnded;

    private GameObject[] cars;

    private void Awake()
    {
        AllowedObstacles = new List<string> { "Obstacle1", "Obstacle2" };
    }

    private void Start()
    {
        winLose = GameObject.FindGameObjectWithTag(Tags.WinLoseDetector).GetComponent<WinLoseDetector>();
    }

    private void Update()
    {
        if (winLose.HasGameStarted() && !hasInitialized && !gameEnded)
        {
            hasInitialized = true;
            cars = GameObject.FindGameObjectsWithTag("Player");
        }

        if (!hasInitialized)
        {
            return;
        }

        var distance = Vector3.Distance(cars[0].transform.position, cars[1].transform.position);

        if (distance < 0.5f)
        {
            PoliceWin();
        }
        else if (distance >= EscapeeWinDistance)
        {
            EscapeeWin();
        }
    }

    public string DirectoryName
    {
        get { return "Obstacles"; }
    }

    public List<string> AllowedObstacles { get; private set; }
    
    public void PoliceWin()
    {
        winLose.EndGame(new List<GameObject> { cars[0] });
    }

    public void EscapeeWin()
    {
        winLose.EndGame(new List<GameObject> { cars[1] });
    }

    public void OnCarCrashed(GameObject car, GameObject rock)
    {
        moveForward = car.GetComponent<MoveForward>();
        moveForward.SpeedCoeffiecient = 0.5f;

        Invoke("RestoreCarSpeed", 1);
    }

    private void RestoreCarSpeed()
    {
        moveForward.SpeedCoeffiecient = 1;
    }
}
