using UnityEngine;

namespace Assets
{
    public class MoveForward : MonoBehaviour
    {
        private float speed = 15f;

        private void Update()
        {
            transform.position += speed * Vector3.forward * Time.deltaTime;
        }

        public float Speed
        {
            get { return speed; }
            set { speed = value; }
        }
    }
}
