using UnityEngine;
using UnityEngine.XR.Hands.Samples.GestureSample;


public class GestureFixer : MonoBehaviour
{
    public StaticHandGesture staticHandGesture;

    void Start()
    {
        // Auto-assign the Static Hand Gesture component if not already assigned
        if (staticHandGesture == null)
        {
            staticHandGesture = GetComponent<StaticHandGesture>();

            if (staticHandGesture == null)
            {
                Debug.LogError("Static Hand Gesture component not found on this GameObject!");
                return;
            }
        }

        // Check and re-enable the script if it's disabled
        if (!staticHandGesture.enabled)
        {
            Debug.Log("Re-enabling Static Hand Gesture script.");
            staticHandGesture.enabled = true;
        }
    }
}
