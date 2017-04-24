namespace Assets
{
    using Asset;
    using UnityEngine;

    public class CrashHandler : MonoBehaviour
    {
        private ICarCrashListener gameMode;

        private void Start()
        {
            gameMode = GameObject.FindGameObjectWithTag(Tags.GameMode).GetComponent<ICarCrashListener>();
        }

        public void OnTriggerEnter(Collider other)
        {
            gameMode.OnCarCrashed(other.gameObject, gameObject);
        }
    }
}