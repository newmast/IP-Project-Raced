using UnityEngine;

namespace Assets
{
    public class MoveForward : MonoBehaviour
    {
        private float speed = 30f;

        private void Update()
        {
            transform.position += speed * Vector3.forward * Time.smoothDeltaTime;
        }

        public float Speed
        {
            get { return speed; }
            set { speed = value; }
        }
    }
}
