namespace Assets
{
    using UnityEngine;

    public class CrashHandler : MonoBehaviour
    {
        public void OnTriggerEnter(Collider other)
        {
            other.gameObject.GetComponent<MoveForward>().Speed = 0;
            GameObject.FindGameObjectWithTag(Tags.WinLoseDetector).GetComponent<WinLoseDetector>().Lose();
        }
    }
}

