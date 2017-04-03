namespace Assets
{
    using UnityEngine;

    public class FollowTarget : MonoBehaviour
    {
        [SerializeField] private GameObject followedObject;

        private void Update()
        {
            transform.LookAt(followedObject.transform);
        }
    }
}
