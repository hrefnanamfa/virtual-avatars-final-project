using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SadPostureController : MonoBehaviour
{
    // Array of target objects to rotate
    public Transform[] targetRotationObjects;
    // Array of target objects to rotate
    public Transform[] targetPositionObjects;


    // Array of rotation values for each target object
    public Vector3[] targetRotations;

    // Array of rotation values for each target object
    public Vector3[] targetPositions;

    void Start()
    {
        // Rotate each target object immediately with specified rotations
        RotateTargetsObjects();
        PositionTargetsObjects();
    }
    void PositionTargetsObjects()
    {
        // Check if targetPositionObjects array is assigned and not empty
        if (targetPositionObjects != null && targetPositionObjects.Length > 0)
        {
            // Check if targetPositions array is assigned and has the same length as targetObjects
            if (targetPositions != null && targetPositionObjects.Length == targetPositionObjects.Length)
            {
                for (int i = 0; i < targetPositionObjects.Length; i++)
                {
                    print(targetPositions[i]);
                    targetPositionObjects[i].localPosition = targetPositions[i];
                }
            }
            else
            {
                Debug.LogWarning("targetTransforms array is not assigned or has an incorrect length.");
            }
        }
        else
        {
            Debug.LogWarning("No target objects assigned or array is empty.");
        }
    }

    void RotateTargetsObjects()
    {
        // Check if targetObjects array is assigned and not empty
        if (targetRotationObjects != null && targetRotationObjects.Length > 0)
        {
            // Check if targetRotations array is assigned and has the same length as targetObjects
            if (targetRotations != null && targetRotations.Length == targetRotationObjects.Length)
            {
                for (int i = 0; i < targetRotationObjects.Length; i++)
                {
                    // Set the rotation directly for each target object
                    targetRotationObjects[i].rotation *= Quaternion.Euler(targetRotations[i]);
                }
            }
            else
            {
                Debug.LogWarning("targetRotations array is not assigned or has an incorrect length.");
            }
        }
        else
        {
            Debug.LogWarning("No target objects assigned or array is empty.");
        }
    }
}
