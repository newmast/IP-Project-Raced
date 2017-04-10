namespace Assets
{
    using UnityEngine;

    public class FollowTarget : MonoBehaviour
    {
        [SerializeField]
        private GameObject followedObject;

        private void Start()
        {
            transform.LookAt(followedObject.transform);
        }
    }
}
