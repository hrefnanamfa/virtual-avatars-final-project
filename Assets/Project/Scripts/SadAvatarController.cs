using UnityEngine;

public class SadAvatarController : MonoBehaviour
{
    // Reference to SkinnedMeshRenderer components
    public SkinnedMeshRenderer bodyRenderer;
    public SkinnedMeshRenderer defaultRenderer;

    public Transform spineTarget;

    public Transform rightArmHint;
    public Transform leftArmHint;
    public Transform rightLegHint;
    public Transform leftLegHint;

    public Vector3 spineTargetRotation;

    public Vector3 rightArmHintPosition;
    public Vector3 leftArmHintPosition;
    public Vector3 rightLegHintPosition;
    public Vector3 leftLegHintPosition;

    void Start()
    {
        // Check if SkinnedMeshRenderer components are assigned
        if (bodyRenderer == null || defaultRenderer == null)
        {
            Debug.LogError("SkinnedMeshRenderer components not assigned!");
            return;
        }

        // Rotate each target object immediately with specified rotations
        RotateTargetsObjects();
        // Position each target object immediately with specified positions
        PositionTargetsObjects();
        // Make sad blendshape face
        AddSadBlendShape();
    }

    void AddSadBlendShape()
    {
        SetBlendShapeWeight(4, 28.9f);
        SetBlendShapeWeight(5, 40.2f);

        SetBlendShapeWeight(6, 11.1f);
        SetBlendShapeWeight(7, 10.2f);

        SetBlendShapeWeight(14, 72.9f);
        SetBlendShapeWeight(15, 74.8f);

        SetBlendShapeWeight(28, 36f);
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

    void RotateTargetsObjects()
    {
        // Set the rotation directly
        spineTarget.rotation *= Quaternion.Euler(spineTargetRotation);
    }

    void PositionTargetsObjects()
    {
        rightArmHint.localPosition = rightArmHintPosition;
        leftArmHint.localPosition = leftArmHintPosition;
        rightLegHint.localPosition = rightLegHintPosition;
        leftLegHint.localPosition = leftLegHintPosition;
    }
}
