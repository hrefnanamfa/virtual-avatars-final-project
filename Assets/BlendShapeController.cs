using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlendShapeController : MonoBehaviour
{
    // Reference to SkinnedMeshRenderer components
    public SkinnedMeshRenderer bodyRenderer;
    public SkinnedMeshRenderer defaultRenderer;

    public bool isHappy;

    void Start()
    {
        // Check if SkinnedMeshRenderer components are assigned
        if (bodyRenderer == null || defaultRenderer == null)
        {
            Debug.LogError("SkinnedMeshRenderer components not assigned!");
            return;
        }

        if(!isHappy)
        {
            SetBlendShapeWeight(4, 28.9f); // Set both body & default blend shape index
            SetBlendShapeWeight(5, 40.2f); // Set both body & default blend shape index

            SetBlendShapeWeight(6, 11.1f); // Set both body & default blend shape index
            SetBlendShapeWeight(7, 10.2f); // Set both body & default blend shape index

            SetBlendShapeWeight(14, 72.9f); // Set both body & default blend shape index
            SetBlendShapeWeight(15, 74.8f); // Set both body & default blend shape index

            SetBlendShapeWeight(28, 36f); // Set both body & default blend shape index
        }
    }

    // Function to set the blend shape weight for a specific renderer
    void SetBlendShapeWeight(int blendShapeIndex, float weight)
    {
        // Check if the blend shape index is within valid range
        if (blendShapeIndex >= 0 && blendShapeIndex < bodyRenderer.sharedMesh.blendShapeCount)
        {
            // Set the blend shape weight
            bodyRenderer.SetBlendShapeWeight(blendShapeIndex, weight);
            defaultRenderer.SetBlendShapeWeight(blendShapeIndex, weight);
        }
        else
        {
            Debug.LogWarning("Blend shape index out of range for " + bodyRenderer.gameObject.name);
        }
    }
}
