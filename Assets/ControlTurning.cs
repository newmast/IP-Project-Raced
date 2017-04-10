namespace Assets
{
    using UnityEngine;

    public class ControlTurning : MonoBehaviour
    {
        private float turnSpeed = 5f;
        private float speedDeclineCoefficient = 1.4f;
        private Vector3 turnVelocity;
        
        private void Update()
        {
            turnVelocity.x /= speedDeclineCoefficient;
#if UNITY_EDITOR || UNITY_STANDALONE
            if (Input.GetKey(KeyCode.LeftArrow))
            {
                turnVelocity.x -= turnSpeed;
            }
            else if (Input.GetKey(KeyCode.RightArrow))
            {
                turnVelocity.x += turnSpeed;
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
