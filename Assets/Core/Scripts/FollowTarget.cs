using System.Collections;
using System.Collections.Generic;
using UnityEngine;


// Jeremy was here


namespace FrameWorks.Core
{
    public class FollowTarget : MonoBehaviour
    {
        [SerializeField] private Transform m_target;
        [SerializeField] private Vector3 followOffset;
        [SerializeField] private float smoothTime = 0.1f;

        [SerializeField] private bool orientToMovement = false;

        private Vector3 velocity;
        

        private bool canFollow = true;

        private void Update()
        {
            if (m_target == null) return;
            if (canFollow == false) return;

            Vector3 followVector = m_target.position;
            Vector3 offset = (m_target.right * followOffset.x) + (m_target.up * followOffset.y) + (m_target.forward * followOffset.z);

            followVector += offset;

            //transform.position = Vector3.MoveTowards(transform.position, m_target.position, 10 * Time.deltaTime);

            transform.position = Vector3.SmoothDamp(transform.position, followVector, ref velocity, smoothTime);

            if (orientToMovement)
            {
                Vector3 directionToTarget = followVector - transform.position;
                Quaternion rotation = Quaternion.LookRotation(directionToTarget, Vector3.up);
                transform.rotation = Quaternion.Slerp(transform.rotation, rotation, 0.5f);
            }
        }

        public void SetTarget(Transform target)
        {
            m_target = target;
        }

        public void SetCanFollow(bool value)
        {
            this.canFollow = value;
        }
    }
}


