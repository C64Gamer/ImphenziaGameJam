using UnityEngine;

namespace Core
{
    public class SpaceShipController : MonoBehaviour
    {

        [Header("General Settings")] public bool isActive = true;
        public float shipSpeed = 1;
        public float sideForce = 130;
        public float maxAngle = 35;
        public float resetSpeed = 130;

        // Update is called once per frame
        void Update()
        {
            CheckMaxFlightAngle();
            DoBasicMovement();
        }

        private void CheckMaxFlightAngle()
        {
            var currentZRotation = UnityEditor.TransformUtils.GetInspectorRotation(transform).z;
            
            //TODO Cleanup code
            if (currentZRotation < -maxAngle)
            {
                Vector3 tmp = transform.rotation.eulerAngles;
                tmp.z = -maxAngle;
                Debug.Log(tmp);
                transform.rotation = Quaternion.Euler(tmp);
            }

            if (currentZRotation > maxAngle)
            {
                Vector3 tmp = transform.rotation.eulerAngles;
                tmp.z = maxAngle;
                transform.rotation = Quaternion.Euler(tmp);
            }
        }

        private void DoBasicMovement()
        {
            if (Input.GetKey(KeyCode.A))
            {
                transform.position += Vector3.left * (shipSpeed * Time.deltaTime);
                transform.Rotate(0, 0, sideForce * Time.deltaTime, Space.World);
            }

            if (Input.GetKey(KeyCode.D))
            {
                transform.position += Vector3.right * (shipSpeed * Time.deltaTime);
                transform.Rotate(0, 0, -sideForce * Time.deltaTime, Space.World);
            }

            if (Input.GetKey(KeyCode.W))
            {
                transform.position += Vector3.forward * (shipSpeed * Time.deltaTime);
            }
            
            if (Input.GetKey(KeyCode.S))
            {
                transform.position += Vector3.back * (shipSpeed * Time.deltaTime);
            }
        }
    }
}
