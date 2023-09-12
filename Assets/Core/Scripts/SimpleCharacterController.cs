using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

namespace FrameWorks.Core
{
    [RequireComponent(typeof(CharacterController))]
    public class SimpleCharacterController : MonoBehaviour
    {
        private CharacterController m_locomotion;

        [SerializeField] private CinemachineVirtualCamera cam1;
        [SerializeField] private CinemachineVirtualCamera cam2;

        [Header("Attributes")]
        [SerializeField] private float moveSpeed = 5.0f;

        private void Awake()
        {
            m_locomotion = GetComponent<CharacterController>();

            
        }

        private void Update()
        {
            float x = Input.GetAxis("Horizontal");
            float z = Input.GetAxis("Vertical");

            Vector3 translation = (Vector3.right * x) + (Vector3.forward * z);

            m_locomotion.SimpleMove(translation.normalized * moveSpeed);

            if (Input.GetKeyDown(KeyCode.Space))
            {
                GetComponent<CinemachineImpulseSource>().GenerateImpulse();
            }

            if (Input.GetKeyDown("1"))
            {
                Cursor.lockState = CursorLockMode.Locked;
                Cursor.visible = false;
            }
            if (Input.GetKey("2"))
            {
                Cursor.lockState = CursorLockMode.None;
                Cursor.visible = true;
            }

            if (Input.GetKeyDown(KeyCode.Alpha3))
            {
                cam1.Priority = 11;
                cam2.Priority = 15;
            }

            if (Input.GetKeyDown(KeyCode.Alpha4))
            {
                cam1.Priority = 15;
                cam2.Priority = 11;
            }
        }
    }
}


