namespace Assets
{
    using Asset;
    using UnityEngine;

    public class CrashHandler : MonoBehaviour
    {
        private ICarCrashListener gameMode;

        private void Start()
        {
        }

        public void OnTriggerEnter(Collider other)
        {
            if (gameMode == null)
            {
                gameMode = GameObject.FindGameObjectWithTag(Tags.GameMode).GetComponent<ICarCrashListener>();
            }

            gameMode.OnCarCrashed(other.gameObject, gameObject);
        }
    }
}