namespace Assets
{
    using UnityEngine;

    public class MoveForward : MonoBehaviour
    {
        private WinLoseDetector winLose;

        private float speed = 0f;

        public void Start()
        {
            winLose = GameObject.FindGameObjectWithTag(Tags.WinLoseDetector).GetComponent<WinLoseDetector>();
        }

        private void Update()
        {
            if (winLose.HasGameStarted())
            {
                speed = 5f;
            }

            transform.position += speed * Vector3.forward * Time.smoothDeltaTime;
        }

        public float Speed
        {
            get { return speed; }
            set { speed = value; }
        }
    }
}
