namespace Asset
{
    using UnityEngine;

    public interface ICarCrashListener
    {
        void OnCarCrashed(GameObject car, GameObject rock);
    }
}