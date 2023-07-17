using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace FrameWorks.Core
{
    [RequireComponent(typeof(CharacterController))]
    public class SimpleCharacterController : MonoBehaviour
    {
        private CharacterController m_locomotion;        

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
        }
    }
}


