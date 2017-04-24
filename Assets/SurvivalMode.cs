namespace Asset
{
    using System;
    using Assets;
    using UnityEngine;
    using UnityEngine.Networking;

    public class SurvivalMode : NetworkBehaviour, ICarCrashListener
    {
        private WinLoseDetector winLose;
        private CrashHandler crashHandler;

        private void Start()
        {
            winLose = GameObject.FindGameObjectWithTag(Tags.WinLoseDetector).GetComponent<WinLoseDetector>();


            //other.gameObject.GetComponent<MoveForward>().Speed = 0;
            GameObject.FindGameObjectWithTag(Tags.WinLoseDetector).GetComponent<WinLoseDetector>().EndGame();

        }

        public void OnCarCrashed(GameObject car, GameObject rock)
        {
            throw new NotImplementedException();
        }
    }
}
