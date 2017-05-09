namespace Assets
{
    using UnityEngine;

    public class CoinManager : MonoBehaviour
    {
        private ICoinGathering coinGatherer;
        private Transform target;
        private GameObject[] players;

        private void Start()
        {
            coinGatherer = GameObject.FindGameObjectWithTag(Tags.GameMode).GetComponent<ICoinGathering>();
            target = GameObject.FindGameObjectWithTag(Tags.CameraTarget).transform;

            coinGatherer.AddCoinsToTotalPile(1);
        }

        private void Update()
        {
            if (players == null)
            {
                players = GameObject.FindGameObjectsWithTag("Player");
                return;
            }

            var targetPosition = Mathf.Min(
                players[0].transform.position.z,
                players[1].transform.position.z);

            if (transform.position.z < targetPosition - Constants.RoadLength * 0.5f)
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
