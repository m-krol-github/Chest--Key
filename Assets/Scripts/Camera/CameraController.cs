using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace CameraControll
{
    public class CameraController : MonoBehaviour
    {
        public float panSpeed = 20f;
        public float rotateSpeed = 20f;
        public float panBorder = 10f;

        [SerializeField]
        private Vector2 dir;

        private void Update()
        {    
            
            if (Input.GetKey(KeyCode.W))
            {
                transform.Translate(Vector3.forward * panSpeed * Time.deltaTime,Space.Self);
            }
            if (Input.GetKey(KeyCode.S))
            {
                transform.Translate(Vector3.back * panSpeed * Time.deltaTime, Space.Self);
            }
            if (Input.GetKey(KeyCode.D))
            {
                transform.Translate(Vector3.right * panSpeed * Time.deltaTime, Space.Self);
            }
            if (Input.GetKey(KeyCode.A))
            {
                transform.Translate(Vector3.left * panSpeed * Time.deltaTime, Space.Self);
            }
            if (Input.GetKey(KeyCode.Q))
            {
                transform.Rotate(Vector3.up * Time.deltaTime * -rotateSpeed * 4, Space.World);
            }
            if (Input.GetKey(KeyCode.E))
            {
                transform.Rotate(Vector3.down * Time.deltaTime * -rotateSpeed * 4, Space.World);
            }

        }

    }
}