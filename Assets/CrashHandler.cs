namespace Assets
{
    using System;
    using UnityEngine;

    public class CrashHandler : MonoBehaviour
    {
        public void OnTriggerEnter(Collider other)
        {
            if (OnCarCrashed != null)
            {
                OnCarCrashed.Invoke(other);
            }
        }

        public Action<Collider> OnCarCrashed { get; set; }
    }
}