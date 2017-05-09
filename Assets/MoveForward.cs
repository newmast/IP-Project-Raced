namespace Assets
{
    using UnityEngine;

    public class MoveForward : MonoBehaviour
    {
        private WinLoseDetector winLose;
        private float speed = 0f;

        private void Awake()
        {
            SpeedCoeffiecient = 1;
        }

        private void Start()
        {
            winLose = GameObject.FindGameObjectWithTag(Tags.WinLoseDetector).GetComponent<WinLoseDetector>();
        }

        private void Update()
        {
            if (winLose.HasGameStarted())
            {
                speed = 5f;
            }

            transform.position += SpeedCoeffiecient * speed * Vector3.forward * Time.smoothDeltaTime;
        }
        
        public float SpeedCoeffiecient { get; set; }
    }
}
