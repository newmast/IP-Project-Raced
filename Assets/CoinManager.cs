namespace Assets
{
    using UnityEngine;

    public class CoinManager : MonoBehaviour
    {
        private ICoinGathering coinGatherer;
        private Transform target;

        private void Start()
        {
            coinGatherer = GameObject.FindGameObjectWithTag(Tags.GameMode).GetComponent<ICoinGathering>();
            target = GameObject.FindGameObjectWithTag(Tags.CameraTarget).transform;

            coinGatherer.AddCoinsToTotalPile(1);
        }

        private void Update()
        {
            if (transform.position.z < target.position.z - Constants.RoadLength * 0.5f)
            {
                coinGatherer.OnCoinMissed();
            }
        }

        private void OnTriggerEnter(Collider other)
        {
            coinGatherer.OnCoinTaken(other.gameObject, gameObject);
        }
    }
}
