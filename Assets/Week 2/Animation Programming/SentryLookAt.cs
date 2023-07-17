using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.Animations.Rigging;

namespace FrameWorks.Week2
{
    public class SentryLookAt : MonoBehaviour
    {
        [SerializeField] private Transform ikComponent;
        [SerializeField] private Transform target;

        // Not necessarily tied to animations.
        // Just lets you create a graph on the inspector 
        // Can be used to create relations between x and y. More about it in update
        [SerializeField] private AnimationCurve distanceToAlphaCurve;

        private void Update()
        {
            if (target != null)
            {

                // We calculate our distance first and then pass it onto the graph.
                // The evaluate function will return the y value based on the x value we pass in (distance)
                // The y value is then used to lerp the x rotation between 0 and 90 degrees. 
                // This allows us to make the neck to rotate downwards between a specific range

                float distance = Vector3.Distance(transform.position, target.position);
                Debug.Log($"The distance is: {distance}");
                float alpha = distanceToAlphaCurve.Evaluate(distance);
                float rotX = Mathf.Lerp(0, 90, alpha);

                // We first calculate the direction between this gameobject and the target
                // This can then be used to calculate a rotation (LookRotation).
                // The second parameter is asking what this angle is relative to. 
                // In this case we are calculating based on the world. Use transform.up to calculate angle relative to the object instead.
                // We use this to calculate the upwards rotation (y axis).

                Vector3 directionToTarget = (target.position - transform.position).normalized; // Get Direction
                Vector3 lookRotEuler = Quaternion.LookRotation(directionToTarget, Vector3.up).eulerAngles; // Calculate Rotation from direction and get in vector 3 format
                lookRotEuler.x = rotX;

                Quaternion finalRotation = Quaternion.Euler(lookRotEuler);
                ikComponent.rotation = Quaternion.Slerp(ikComponent.rotation, finalRotation, 0.5f);
            }
        }
    }
}


