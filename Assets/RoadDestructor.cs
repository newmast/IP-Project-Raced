namespace Assets
{
    using UnityEngine;

    public class RoadDestructor : MonoBehaviour
    {
        private MoveForward target;

        private void Start()
        {
            target = GameObject.FindGameObjectWithTag(Tags.CameraTarget).GetComponent<MoveForward>();
        }

        private void Update()
        {
            var roadPosition = transform.position;

            if (roadPosition.z < target.transform.position.z - Constants.RoadLength * 2f)
            {
                Destroy(gameObject);
            }
        }
    }
}
