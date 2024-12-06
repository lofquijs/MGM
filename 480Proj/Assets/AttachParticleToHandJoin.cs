using UnityEngine;

public class AttachParticleToHandJoint : MonoBehaviour
{
    public Transform hand; // Reference to the hand object (e.g., LeftHand or RightHand)
    public string jointName = "index_finger_tip"; // Name of the fingertip joint
    public ParticleSystem particleSystem; // The Particle System to attach

    private Transform jointTransform;

    void Start()
    {
        // Find the joint transform within the hand hierarchy
        if (hand != null)
        {
            jointTransform = FindChildByName(hand, jointName);
        }

        if (jointTransform == null)
        {
            Debug.LogError($"Joint '{jointName}' not found in the hand hierarchy.");
            enabled = false;
        }
    }

    void Update()
    {
        if (jointTransform != null && particleSystem != null)
        {
            // Move the Particle System to the joint's position
            particleSystem.transform.position = jointTransform.position;

            // Optionally, match the joint's rotation
            particleSystem.transform.rotation = jointTransform.rotation;
        }
    }

    // Helper function to recursively find a child by name
    private Transform FindChildByName(Transform parent, string name)
    {
        foreach (Transform child in parent)
        {
            if (child.name == name)
            {
                return child;
            }
            Transform found = FindChildByName(child, name);
            if (found != null)
            {
                return found;
            }
        }
        return null;
    }
}
