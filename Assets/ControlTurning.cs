namespace Assets
{
    using UnityEngine;
    using UnityEngine.Networking;

    public class ControlTurning : NetworkBehaviour
    {
        private float turnSpeed = 270f;
        private float speedDeclineCoefficient = 1.4f;
        private Vector3 turnVelocity;

        private void Start()
        {
            if (!isLocalPlayer)
            {
                Destroy(this);
                return;
            }
        }

        private void Update()
        {
            turnVelocity.x /= speedDeclineCoefficient;
#if UNITY_EDITOR || UNITY_STANDALONE

        
            if (Input.GetKey(KeyCode.LeftArrow))
            {
                turnVelocity.x -= turnSpeed * Time.deltaTime;
            }
            else if (Input.GetKey(KeyCode.RightArrow))
            {
                turnVelocity.x += turnSpeed * Time.deltaTime;
            }

#else
            var fingerPressX = Input.GetTouch(Input.touchCount - 1).position.x;
            var width = Screen.width;

            if (fingerPressX < width / 2f)
            {
                turnVelocity.x -= turnSpeed;
            }
            else
            {
                turnVelocity.x += turnSpeed;
            }
#endif

            var newPosition = transform.position + turnVelocity * Time.deltaTime;
            newPosition.x = Mathf.Clamp(
                newPosition.x,
                -Constants.RoadWidth / 2f + Constants.CarWidth / 2f,
                Constants.RoadWidth / 2f - Constants.CarWidth / 2f);

            transform.position = newPosition;
        }
    }
}
